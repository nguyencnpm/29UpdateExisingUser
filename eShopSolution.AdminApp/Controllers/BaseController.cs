using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eShopSolution.AdminApp.Controllers
{
    public class BaseController : Controller
    {
        [Authorize]
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var secsion = context.HttpContext.Session.GetString("Token");
            if (secsion==null)
            {
                context.Result = RedirectToAction("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
