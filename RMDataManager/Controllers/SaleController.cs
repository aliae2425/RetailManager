using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    public class SaleController : ApiController
    {
        //POST: Sale - Create a new sale
        public void Post([FromBody] SaleModel sale)
        {
        }
    }
}