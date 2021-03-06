using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page!!!";

            return View();
        }

        public ActionResult Test()
        {
            return PartialView();
        }

        public ActionResult Short(string shortUrl)
        {
            return Content(shortUrl);
        }

        public ActionResult Metro()
        {
            return View();
        }
    }
}