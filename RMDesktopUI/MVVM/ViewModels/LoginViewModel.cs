using Caliburn.Micro;
using RMDesktopUI.Helpers;
using RMDesktopUI.Library.API;
using RMDesktopUI.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RMDesktopUI.MVVM.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private IAPIHelper _apiHelper;

        public LoginViewModel( IAPIHelper ApiHelper)
        {
            _apiHelper = ApiHelper;
        }

        public string Username
        {
            get { return _username; }
            set 
            { 
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;
                if(ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
            
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value; 
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;

                if (Username?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = string.Empty;
                var result = await _apiHelper.Authenticate(Username, Password);
                // TODO: Capture more information about the user
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        
    }
}
