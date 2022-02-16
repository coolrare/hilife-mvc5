using MVC5Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user, string ReturnUrl)
        {
            if (ModelState.IsValid && ValidateLogin(user))
            {
                FormsAuthentication.RedirectFromLoginPage(user.Username, true);

                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("Index", "Courses");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            return View();
        }

        public ActionResult Logout(string ReturnUrl)
        {
            FormsAuthentication.SignOut();

            if (String.IsNullOrEmpty(ReturnUrl))
            {
                return RedirectToAction("Index", "Courses");
            }
            else
            {
                return Redirect(ReturnUrl);
            }
        }

        private bool ValidateLogin(LoginViewModel user)
        {
            return true;
        }
    }
}