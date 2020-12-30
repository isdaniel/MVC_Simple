using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Xml.Linq;
using log4net;
using Newtonsoft.Json;

namespace LibraryController.infrastructure
{
    public class CustomAuthorizeAttribute : 
        FilterAttribute,IAuthorizationFilter
    {
        private ILog _log = LogManager.GetLogger(typeof(CustomAuthorizeAttribute));

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //取得Controller是否有IgnoreAuthorizeAttribute
            var isControllerIngnore = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(IgnoreAuthorizeAttribute), false);
            //取得Action是否有IgnoreAuthorizeAttribute
            var isActionIngnore = filterContext.ActionDescriptor.IsDefined(typeof(IgnoreAuthorizeAttribute), false);
            if (!isControllerIngnore & !isActionIngnore)
            {
                if (!AuthorizeCore(filterContext.HttpContext))
                {
                    UnauthorizedRequest(filterContext);
                }
            }
        }
        protected bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SessionData.UserInfo!= null)
            {
                _log.Info($"登入成功 使用者是:{SessionData.UserInfo.UserName}");
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