using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete
{
    public class Ingredient
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public string IngredientType { get; set; }
        public int Price { get; set; }
        public string RestaurantId { get; set; }
    }
}
