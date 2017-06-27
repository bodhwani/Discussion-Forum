using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            System.Diagnostics.Debug.WriteLine("---Entered into Index function in home");
            return View();

        }

        [Route("Home/About")]
        [HttpGet]
        public string  About()
        {
            System.Diagnostics.Debug.WriteLine("---Entered into About function in home");
            return "hello";
        }
    }
}
