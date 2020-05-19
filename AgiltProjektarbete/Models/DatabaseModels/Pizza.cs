using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiltProjektarbete
{
    public class Pizza
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public string RestaurantId { get; set; }
        public string OrderId { get; set; } 
        public string Name { get; set; }
        [NotMapped]
        public List<Ingredient> Ingredients { get; set; }
        public int Price { get; set; }
        public bool InMenu { get; set; }
    }
}