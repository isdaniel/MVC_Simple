using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace LibraryController.infrastructure
{
    public class CustomerErrorAtrribute: HandleErrorAttribute
    {
        private ILog _log = LogManager.GetLogger(typeof(CustomerErrorAtrribute));
        public override void OnException(ExceptionContext filterContext)
        {
            _log.Error(filterContext.Exception.Message, filterContext.Exception);
            filterContext.Result = new RedirectResult("~/Error/ErrorPage");
            filterContext.ExceptionHandled = false;
        }
    }
}