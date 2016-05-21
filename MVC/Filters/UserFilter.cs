using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserFilterAttribute : AuthorizeAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //var content = filterContext.HttpContext;
        //    ////var ad = filterContext.ActionDescriptor;
        //    ////string user=content.Session["User"] as string;
        //    //string first = content.Session["IsLogin"] as string;
        //    //if (string.IsNullOrEmpty(first))
        //    //{
        //    //    filterContext.Result = new RedirectResult(
        //    //        "http://localhost:11230/Home/User/Index");
        //    //}
        //}
        //private bool _isAuthorized;

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    base.OnAuthorization(filterContext);

        //    if (!_isAuthorized)
        //    {
        //        filterContext.Controller.TempData.Add("RedirectReason", "Unauthorized");
        //    }
        //}

        //protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        //{
        //    _isAuthorized = base.AuthorizeCore(httpContext);
        //    return _isAuthorized;
        //}
    }
}