﻿using System.ComponentModel;

namespace gym_management_system_front_end.Models
{
    public class CartViewModel
    {

        [DisplayName("Supplement ID ")]
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string? imageURL { get; set; }
    }
}
