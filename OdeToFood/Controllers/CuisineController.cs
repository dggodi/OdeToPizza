using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    // user must be logged in
    [Authorize]
    public class CuisineController : Controller
    {
        // /cuisine/search
        // prameter:
        // - name     - value of search in url
        [HttpGet]
        public ActionResult Search(string name = "French")
        {
            // returns value from url if malicous code is not entered in the url
            var message = Server.HtmlEncode(name);

            // returns a string literal
            return Content(message);

            // returns a view form the view folder
            //return View();

            // redirect to a url permanently
            // return RedirectPermanent(url);

            // redirect to the "Index" method in the "HomeController
            //      RedirectToAction     - returns the approriate url from the routing engine 
            //      new { name = name}   - passes a anonomus parameter
            //return RedirectToAction("Index", "Home", new { name = name });

            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });

            //return Json(new { Message = message, Name = "David" }, JsonRequestBehavior.AllowGet);
        }
    }
}