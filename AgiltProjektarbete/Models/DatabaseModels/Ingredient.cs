using System.ComponentModel.DataAnnotations.Schema;

namespace AgiltProjektarbete
{
    public class Ingredient
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public string IngredientType { get; set; }
        public int Price { get; set; }
        public string RestaurantId { get; set; }
        public bool InMenu { get; set; }
    }
}