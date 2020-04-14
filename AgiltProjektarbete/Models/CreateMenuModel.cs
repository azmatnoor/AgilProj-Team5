using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete
{
    public class CreateMenuModel
    {
        public Pizza Pizza { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Pizza> CurrentMenu { get; set; }
    }
}
