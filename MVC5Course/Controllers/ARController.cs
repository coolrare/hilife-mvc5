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
    }
}