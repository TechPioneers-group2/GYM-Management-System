﻿namespace GYM_Management_System.Models.DTOs
{
    public class CreatEmployeeDTO
    {
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }



    }

}
