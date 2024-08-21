using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : Controller
    {
        // GET: User/Details/5
        public ActionResult GetById(int id)
        {
            UserData

            return View();
        }

    }
}
