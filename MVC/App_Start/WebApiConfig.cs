using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //// 在這邊註冊剛剛寫好的AuthenticationMessageHandler
            //config.MessageHandlers.Add(new AuthorizHttpMsg());
        }
    }
}