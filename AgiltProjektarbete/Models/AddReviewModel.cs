using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete
{
    public class AddReviewModel
    {
        public string Message { get; set; }
        public string RestaurantId { get; set; }
        public string CustomerId { get; set; }
        public bool CustomerReview { get; set; }
    }
}
