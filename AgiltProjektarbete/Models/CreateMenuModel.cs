using System.Collections.Generic;

namespace AgiltProjektarbete
{
    public class CreateMenuModel
    {
        public Pizza Pizza { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Pizza> CurrentMenu { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
