using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [Authorize]
    [HandleError(View = "Error.DbEntityValidationException", ExceptionType = typeof(DbEntityValidationException))]
    public abstract class MemberBaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/?wrongView=" + actionName).ExecuteResult(this.ControllerContext);
        }
    }
}