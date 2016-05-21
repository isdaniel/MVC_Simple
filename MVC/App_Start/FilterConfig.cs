using MVC.Filters;
using System.Web.Mvc;

namespace MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new UserFilterAttribute());
        }
    }
}