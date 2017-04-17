using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

// - controller     - controller name
// - action         - method name
// - id             - parameter
namespace OdeToFood
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // allows you to retreive a files on the disc {css file, images}
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // map cuisine/{name} to controller to "Cuisine"
            // note: matches "/cuisine", "cuisine/meatballs"
            //       name is optional
            routes.MapRoute("Cuisine", "cuisine/{name}",
                new { controller = "Cuisine", action = "search", name = UrlParameter.Optional });
            
            // url mapping - id is an optinal parameter and is set by default
            // note: matches "/", "/Home, "/Home/index", "/Home/idex/id"
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",  //  /Home/index
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
