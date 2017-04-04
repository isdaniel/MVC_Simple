using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Xml.Linq;

namespace LibraryController.infrastructure
{
    public class CustomAuthorizeAttribute : 
        FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //取得Controller是否有IgnoreAuthorizeAttribute
            var IsControllerIngnore = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(IgnoreAuthorizeAttribute), false);
            //取得Action是否有IgnoreAuthorizeAttribute
            var IsActionIngnore = filterContext.ActionDescriptor.IsDefined(typeof(IgnoreAuthorizeAttribute), false);
            if (!IsControllerIngnore & !IsActionIngnore)
            {
                if (!AuthorizeCore(filterContext.HttpContext))
                {
                    UnauthorizedRequest(filterContext);
                }
            }
        }
        protected bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Callid"]!=null)
            {
                Logger log = new Logger(this.GetType());
                log.WriteSusseccLog(string.Format("登入成功 使用者是:{0}", 
                    httpContext.Session["Callid"].ToString()));
                var Id = httpContext.Session["Callid"];
                httpContext.Session["Callid"] = Id;                
                return true;
            }
            return false;
        }
        protected void UnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/User/Login");
        }
    }
}