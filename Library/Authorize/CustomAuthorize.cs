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
            string username = filterContext.HttpContext.User.Identity.Name;
            Logger log = new Logger(this.GetType());
            base.OnAuthorization(filterContext);
            if (!string.IsNullOrEmpty(username))
                log.WriteSusseccLog(String.Format("登入成功 使用者是:{0}", username));
        }
    }
}