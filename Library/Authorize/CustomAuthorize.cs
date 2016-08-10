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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public new string[] Roles { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string username = filterContext.HttpContext.User.Identity.Name;
            Logger log = new Logger(this.GetType());
            base.OnAuthorization(filterContext);
            if (!string.IsNullOrEmpty(username))
                log.WriteSusseccLog(String.Format("登入成功 使用者是:{0}", username));
        }

        //public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        //{
        //    string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //    string actionName = filterContext.ActionDescriptor.ActionName;
        //    string roles = GetRoles.GetActionRoles(actionName, controllerName);
        //    if (!string.IsNullOrWhiteSpace(roles))
        //    {
        //        this.Roles = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //    }
        //    base.OnAuthorization(filterContext);
        //}
    }

    //public class GetRoles
    //{
    //    public static XElement findElementByAttribute(XElement xElement, string tagName, string attribute)
    //    {
    //        return xElement.Elements(tagName).FirstOrDefault(x => x.Attribute("name").Value.Equals(attribute, StringComparison.OrdinalIgnoreCase));
    //    }

    //    public static string GetActionRoles(string action, string controller)
    //    {
    //        XElement rootElement = XElement.Load(HttpContext.Current.Server.MapPath("/") + "ActionRoles.xml");
    //        XElement controllerElement = findElementByAttribute(rootElement, "Controller", controller);
    //        if (controllerElement != null)
    //        {
    //            XElement actionElement = findElementByAttribute(controllerElement, "Action", action);
    //            if (actionElement != null)
    //            {
    //                return actionElement.Value;
    //            }
    //        }
    //        return "";
    //    }
    //}
}