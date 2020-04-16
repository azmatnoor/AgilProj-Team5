using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AgiltProjektarbete
{
    public class Menu
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        [ForeignKey("Id")]
        public virtual Restaurant Restaurant { get; set; }
    }
}