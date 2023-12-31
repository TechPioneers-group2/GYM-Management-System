﻿namespace GYM_Management_System.Models.DTOs
{
    public class SupplementDTO
    {
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? imageURL { get; set; }
    }


    public class GetGymSupplementDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? imageURL { get; set; }
    }

    public class CreatSupplementDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? imageURL { get; set; }
    }
}
