using System.Web;
using System.Web.Mvc;

namespace OdeToFood
{
    public class FilterConfig
    {
        // used to process any http request by a controller
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // displays a error page to the user
            filters.Add(new HandleErrorAttribute());
        }
    }
}
