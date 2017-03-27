using Library.infrastructure;
using System.Web;
using System.Web.Mvc;

namespace Library
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomerErrorAtrribute());
            filters.Add(new CustomAuthorizeAttribute());
        }
    }
}