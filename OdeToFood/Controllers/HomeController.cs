using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();

        // returns like strings that start with term in json format
        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Restaurants
                   .Where(r => r.Name.StartsWith(term))
                   .Take(10)
                   .Select(r => new
                   {
                       label = r.Name
                   });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // location - only cache by server
        [OutputCache(CacheProfile ="Long", VaryByHeader = "X-Requested-With", Location = System.Web.UI.OutputCacheLocation.Server)] // keeps previous response in cache
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            // displays the url for controller/action/id
            //  var controller = RouteData.Values["controller"];
            //  var action = RouteData.Values["action"];
            //  var id = RouteData.Values["id"];

            //  var message = String.Format("{0}::{1} {2}", controller, action, id);
            //  ViewBag.Message = message;

            //var model = from r in _db.Restaurants orderby r.Reviews.Average(review => review.Rating)
            //            select new ResaurantListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            
            var model = _db.Restaurants.OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                        .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                        .Select(r => new ResaurantListViewModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            City = r.City,
                            Country = r.Country,
                            CountOfReviews = r.Reviews.Count()
                        }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
                return PartialView("_Restaurants", model);

            return View(model);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            //ViewBag.Title = "About";
            var aboutModel = new AboutModel();
            aboutModel.Title = "About";
            aboutModel.Name = "david";
            aboutModel.Message = "Your application description page.";
            aboutModel.Location = "Saginaw";


            return View(aboutModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // disposes any open resources
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();

            base.Dispose(disposing);

        }
    }
}