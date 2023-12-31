﻿using System.ComponentModel.DataAnnotations;

namespace GYM_Management_System.Models
{
    public class GymSupplement
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        [Required]
        public int Quantity { get; set; }


        // Navigation props
        public Gym? Gym { get; set; }
        public Supplement? Supplements { get; set; }
    }
}
