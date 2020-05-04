using System;
using System.Collections.Generic;

namespace AgiltProjektarbete
{
    public class FetchBuyModel
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public List<string> IngredientId { get; set; }
    }
}
