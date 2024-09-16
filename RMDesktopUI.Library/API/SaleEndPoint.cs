using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.API
{
    public class SaleEndPoint : ISaleEndPoint
    {
        private IAPIHelper _apiHelper;

        public SaleEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostSale<SaleModel>(SaleModel sale)
        {
            using (HttpResponseMessage httpResponse = await _apiHelper.ApiClient.PostAsJsonAsync("/api/sale", sale))
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    //TODO: Log successful post
                }
                else
                {
                    throw new Exception(httpResponse.ReasonPhrase);
                }
            }
        }
    }
}
