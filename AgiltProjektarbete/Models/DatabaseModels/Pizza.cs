﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgiltProjektarbete
{
    public class Pizza
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<string> Ingredients { get; set; }
        public int Price { get; set; }
    }
}