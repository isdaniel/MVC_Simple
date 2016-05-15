using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class UserFilterAttribute : ActionFilterAttribute
    { 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var userid = HttpContext.Current.Request.Cookies["userid"];
            //var password = HttpContext.Current.Request.Cookies["password"];
            //if (userid == null && password == null)
            //{
            //    HttpContext.Current.Response.Write("未有cookie");
            //    HttpCookie userCookie = new HttpCookie("userid", "trst");
            //    HttpCookie passwordCookie = new HttpCookie("password", "password");
            //    userCookie.Expires = DateTime.Now.AddYears(1);
            //    passwordCookie.Expires = DateTime.Now.AddYears(1);
            //    HttpContext.Current.Response.Cookies.Add(passwordCookie);
            //    HttpContext.Current.Response.Cookies.Add(userCookie);
            //}
            //else
            //{
            //    HttpContext.Current.Response.Write("有cookie");
            //}
        }
    }
}