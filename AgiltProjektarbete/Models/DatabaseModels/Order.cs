﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiltProjektarbete
{
    public class Order
    {
        [Column("id")]
        public virtual string Id { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User Customer { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public int totalPrice { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}