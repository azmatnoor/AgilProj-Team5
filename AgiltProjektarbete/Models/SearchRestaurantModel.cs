using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgiltProjektarbete.Models
{
    public class SearchRestaurantModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [Display(Name="Search")]
        public int SearchValue { get; set; }
    }
}
