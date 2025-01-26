using EternalElegance.Attributes;
using System.Web;
using System.Web.Mvc;

namespace EternalElegance
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
