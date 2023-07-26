using System.Web;
using System.Web.Mvc;

namespace WebAp_MVC_L44_JQuery_With_Model_5223
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
