namespace gym_management_system_front_end.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }
    }

    public class GetEmployeesByGymId
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public string JobDescription { get; set; }

        public bool IsAvailable { get; set; }

        public string WorkingDays { get; set; }

        public string WorkingHours { get; set; }

        public string Salary { get; set; }
    }

    public class CreatEmployeeViewModel
    {
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }



    }

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
        public GymViewModel? Gym { get; set; }


    }
    public class RegisterEmployeeViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }
    }
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
    public class UpdateEmployeeViewModel
    {
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }

        public static explicit operator UpdateEmployeeViewModel(EmployeeViewModel employeeViewModel)
        {
            return new UpdateEmployeeViewModel
            {
                GymID = employeeViewModel.GymID,
                Name = employeeViewModel.Name,
                IsAvailable = employeeViewModel.IsAvailable,
                Salary = employeeViewModel.Salary,
                WorkingDays = employeeViewModel.WorkingDays,
                WorkingHours = employeeViewModel.WorkingHours,
                JobDescription = employeeViewModel.JobDescription,

            };
        }
    }
}

