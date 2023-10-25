using System.ComponentModel;

namespace gym_management_system_front_end.Models
{
    public class RegisterAdminDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }

    }
    public class RegisterEmployeeDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public string UserId { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public bool IsAvailable { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }
        public string Salary { get; set; }
    }
    public class RegisterClientDTO
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }

        [DisplayName("Gym")]
        public int GymID { get; set; }
        public string Name { get; set; }
        public bool InGym { get; set; }

        [DisplayName("subscription Tier")]
        public int SubscriptionTierID { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        public List<GymIDDTO>? GymIDsNames { get; set; }

        public List<GetSubscriptionTierDTO>? SubscriptionTierDTOs { get; set; }

    }
    // public class UserDTO
    // {
    //    public string Id { get; set; }
    //    public string UserName { get; set; }
    //    public string Token { get; set; }
    //    public List<string> Roles { get; set; }
    //}

    public class LogInDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
