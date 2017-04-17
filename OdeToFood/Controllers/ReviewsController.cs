using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();

        //[ChildActionOnly]  // prevents the user from directly calling the url

        // GET: Reviews
        // binds id in url parameter to Restaurant model Id 
        public ActionResult Index([Bind(Prefix ="id")] int restaurantId)
        {
            // static records
            //var bestReview = from r in _reviews orderby r.Rating descending select r;

            //return View(bestReview);

            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        //static List<RestaurantReview> _reviews = new List<RestaurantReview>
        //{
        //    new RestaurantReview {
        //        Id = 1,
        //        Name = "Cinnamon Club",
        //        City="London",
        //        Country="UK",
        //        Rating = 10,
        //    },
        //    new RestaurantReview
        //    {
        //        Id = 2,
        //        Name = "Marrakesh",
        //        City = "D.C",
        //        Country = "USA",
        //        Rating = 10

        //    },
        //    new RestaurantReview
        //    {
        //        Id = 3,
        //        Name = "The House of Elliot",
        //        City = "Ghent",
        //        Country = "Belgium",
        //        Rating = 10
        //    }
        //};
    }
}
