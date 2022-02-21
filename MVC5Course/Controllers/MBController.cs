using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model = "1";
            ViewData["Key1"] = "Key1";
            ViewBag.Key2 = "Key2";

            return View();
        }

        public ActionResult TD()
        {
            TempData["Msg"] = "Success!";

            Session["Msg2"] = "OK";

            return RedirectToAction("Index");
        }
    }
}