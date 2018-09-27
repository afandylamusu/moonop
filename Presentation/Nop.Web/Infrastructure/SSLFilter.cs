using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public class SSLFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsSecureConnection)
            {
                // var url = filterContext.HttpContext.Request.Url.ToString().Replace("http:", "https:");
                filterContext.Result = new RedirectResult("https://localhost:44323/");
            }
        }
    }
}