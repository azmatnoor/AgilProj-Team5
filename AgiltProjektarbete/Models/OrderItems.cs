using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete
{
    public class OrderItems
    {
        public Restaurant Restaurant { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public Dictionary<string, int> Quantity { get; set; } = new Dictionary<string, int>();
    }
}
