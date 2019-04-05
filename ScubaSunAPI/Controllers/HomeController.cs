using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScubaSunAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //AutoGen ag = new AutoGen("ScubaSunAPI", Request.PhysicalApplicationPath + "App_Data/", true);
            return View();
        }
    }
}