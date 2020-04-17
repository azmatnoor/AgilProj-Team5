using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete
{
    public class RestaurantRegistrationModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Display(Name="Zip Code")]
        public string ZIPCode { get; set; }
        [Display(Name = "Price per kilometer")]
        public int PricePerKilometer { get; set; }
        public User currentUser { get; set; }
    }
}
