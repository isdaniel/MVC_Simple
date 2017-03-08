using LibraryBLL;
using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Xml.Linq;

namespace Library.Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            //base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Callid"]!=null)
            {
                Logger log = new Logger(this.GetType());
                log.WriteSusseccLog(String.Format("登入成功 使用者是:{0}", 
                    httpContext.Session["Callid"].ToString()));
                var Id = httpContext.Session["Callid"];
                httpContext.Session["Callid"] = Id;
                return true;
            }
            return false;
            //return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/User/Login");
        }
    }
}