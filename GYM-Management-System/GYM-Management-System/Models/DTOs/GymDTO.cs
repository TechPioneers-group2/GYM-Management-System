namespace GYM_Management_System.Models.DTOs
{
    public class GetUserGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        //NP
        
        public List<EquipmentDTOPut>? Equipments { get; set; }
        public List<GymGetSubscriptionTierDTO>? SubscriptionTier { get; set; }
    }

    public class GetManagerGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        //NP

        public List<GymEquipment> Equipments { get; set; }
        public List<Client> clients { get; set; }
        public List<Employee> employees { get; set; }
        public List<SubscriptionTier> subscriptiontiers { get; set; }
    }

    public class PostGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

    }

    public class PutGymDTO
    {
        public string? Name { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

    }
}
