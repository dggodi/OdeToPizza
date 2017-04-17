using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

namespace OdeToFood
{

    // invked when the app first strats up
    public class MvcApplication : System.Web.HttpApplication
    {
        // invoked when the app starts and before the first http request and any controllers can process a url
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // used to process any http request by a controller
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // splits the url int controller/action/id
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // bundles files together (all css files, all jquery files)
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // used for enity framweork
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
