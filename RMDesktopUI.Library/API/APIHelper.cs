using RMDesktopUI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.API
{
    public class APIHelper : IAPIHelper
    {

        private HttpClient _apiClient;
        private ILoggedInUserModel _loggedInUser;
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedInUser = loggedInUser;
        }

        private void InitializeClient()
        {
            string RequestUrl = ConfigurationManager.AppSettings["apiUrl"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(RequestUrl);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticadedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await _apiClient.PostAsync("/token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticadedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        private void MapResult(LoggedInUserModel userInfo, string Token)
        {
            _loggedInUser.CreateDate = userInfo.CreateDate;
            _loggedInUser.Email = userInfo.Email;
            _loggedInUser.Id = userInfo.Id;
            _loggedInUser.Nom = userInfo.Nom;
            _loggedInUser.Prenom = userInfo.Prenom;

            _loggedInUser.Token = Token;
        }

        public async Task GetLoggedinUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await _apiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    MapResult(result, token);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }
}
