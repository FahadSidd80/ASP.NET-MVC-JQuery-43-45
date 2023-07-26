using System.Web;
using System.Web.Mvc;

namespace WebAp_MVC_L43_JQuery_VC_52123
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
