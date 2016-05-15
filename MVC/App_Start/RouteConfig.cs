using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "home/{controller}/{action}/{page}",
                defaults: new { controller = "User", action = "Index", page = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "All",
                url: "{*values}",
                defaults: new { controller = "Book", action = "Index", page = UrlParameter.Optional }
            );
        }
    }
}