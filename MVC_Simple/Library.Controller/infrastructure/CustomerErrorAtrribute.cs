using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryController.infrastructure
{
    public class CustomerErrorAtrribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Logger log = new Logger(filterContext.Controller.GetType());
            log.WriteErrorLog(filterContext.Exception.Message, filterContext.Exception);
            filterContext.Result = new RedirectResult("~/Error/ErrorPage");
            filterContext.ExceptionHandled = false;
        }
    }
}