﻿namespace gym_management_system.Models
{
    public class Employee
    {
        public string UserId { get; set; }
        public int EmployeeID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }

        //N.P
        public Gym? Gym { get; set; }


    }
}
