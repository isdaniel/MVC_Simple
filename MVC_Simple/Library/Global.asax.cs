
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace Library
{

    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(MvcApplication));

        private string _configFolder;

        protected void Application_Start()
        {
   
            _configFolder = HttpContext.Current.Server.MapPath("\\Configuration\\");
            LoadConfigurations();
            ConfigurationMvcApplication();
        }


        /// <summary>
        /// The function for configuration MVC application.
        /// </summary>
        private void ConfigurationMvcApplication()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Remove(ViewEngines.Engines.OfType<WebFormViewEngine>().First());
        }
        /// <summary>
        ///     The function for end of application.
        /// </summary>
        protected void Application_End()
        {
            var runtime =
                (HttpRuntime)
                typeof(HttpRuntime).InvokeMember("_theRuntime", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField, null, null, null);

            if (runtime != null)
            {
                var shutDownMessage =
                    runtime.GetType()
                        .InvokeMember("_shutDownMessage", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField, null, runtime, null)
                        .ToString();

                var shutDownStack =
                    runtime.GetType()
                        .InvokeMember("_shutDownStack", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField, null, runtime, null)
                        .ToString();

                _log.Info($"ShutDown Message: {shutDownMessage}, Stack: {shutDownStack}");
            }

            _log.Info("Application_End Finish");
        }

        /// <summary>
        /// The function for log application error when application error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/>.
        /// </param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var lastError = this.Server.GetLastError();
            if (lastError != null)
            {
                _log.Error("Application_Error", lastError);
            }
            else
            {
                _log.Error("Application_Error, but lastError is null");
            }
        }


        private void LoadConfigurations()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(_configFolder, "Log4net.config")));
        }
    }
}