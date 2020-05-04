using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgiltProjektarbete
{
    public class Restaurant
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Pizza> Menu { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        [NotMapped]
        public List<Ingredient> Ingredients { get; set; }
        [Required]
        

        public int ZIPCode { get; set; }
        public int PricePerKilometer { get; set; }

    }
}
