using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{

    public class OdeToFoodDB : DbContext
    {
        // db connection located in web.config under <connectionStrings>
        public OdeToFoodDB() : base("name=OdeToFoodContext") { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}