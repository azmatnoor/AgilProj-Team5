using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgiltProjektarbete
{
    public class Restaurant
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Pizza> Menu { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        [NotMapped]
        public List<string> Ingredients { get; set; }
        [Required]
        [MinLength(5)]

        public int ZIPCode { get; set; }
        public int PricePerKilometer { get; set; }

    }
}
