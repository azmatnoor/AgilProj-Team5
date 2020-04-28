using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete.Models
{
    public class OrderItems
    {
        public string RestaurantId { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Dictionary<string, int> Quantity { get; set; } = new Dictionary<string, int>();
    }
}
