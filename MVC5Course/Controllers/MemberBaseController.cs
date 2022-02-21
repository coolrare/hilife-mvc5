using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [Authorize]
    public abstract class MemberBaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/?wrongView=" + actionName).ExecuteResult(this.ControllerContext);
        }
    }
}