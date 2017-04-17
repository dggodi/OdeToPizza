using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name ="User Name")]  // replaces field value
        [DisplayFormat(NullDisplayText ="anonymous")]
        public string ReviewerName { get; set; }
        // FK
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("scott"))
            {
                yield return new ValidationResult("Sorry, Scott, you can't do this");
            }
        }
    }
}