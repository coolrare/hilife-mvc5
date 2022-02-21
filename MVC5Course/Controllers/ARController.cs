using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VR1()
        {
            return View();
        }

        public ActionResult VR2()
        {
            return View("VR1");
        }

        public ActionResult VR3()
        {
            return View("VR1", "_Layout2");
        }

        public ActionResult PR1()
        {
            return PartialView("VR1");
        }

        public ActionResult FR1(string dl)
        {
            if (dl == "1")
            {
                return File(Server.MapPath("~/Content/a0b9830e06ba4a6ea170a85e4b731cdf.jpg"), "image/jpeg", "烏克蘭總統.jpg");
            }
            else
            {
                return File(Server.MapPath("~/Content/a0b9830e06ba4a6ea170a85e4b731cdf.jpg"), "image/jpeg");
            }
        }
    }
}