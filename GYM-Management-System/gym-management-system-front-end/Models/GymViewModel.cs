namespace gym_management_system_front_end.Models
{
    public class GymViewModel
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
        public List<GymSupplementDTO>? Supplements { get; set; }
    }

    public class EquipmentDTOPut
    {
        public int GymEquipmentID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }

    }

    public class GymSupplementDTO
    {
        public int SupplementID { get; set; }
        //public int GymID { get; set; }
        public int Quantity { get; set; }

        // Navigation props
        public GetGymSupplementDTO? Supplements { get; set; }

    }

    public class GymGetSubscriptionTierDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }

    public class GetGymSupplementDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }

    }

    public class PostGymDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }
    }

    public class PutGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        public static explicit operator GymViewModel(PutGymDTO gym)
        {
            return new GymViewModel
            {
                GymID = gym.GymID,
                Name = gym.Name,
                Address = gym.Address,
                MaxCapacity = gym.MaxCapacity,
                CurrentCapacity = gym.CurrentCapacity,
                ActiveHours = gym.ActiveHours,
                Notification = gym.Notification,
            };
        }

        public static explicit operator PutGymDTO(GymViewModel gym)
        {
            return new PutGymDTO
            {
                GymID = gym.GymID,
                Name = gym.Name,
                Address = gym.Address,
                MaxCapacity = gym.MaxCapacity,
                CurrentCapacity = gym.CurrentCapacity,
                ActiveHours = gym.ActiveHours,
                Notification = gym.Notification,
            };
        }

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

        public List<GymSupplementDTO>? Supplements { get; set; }
        public List<EquipmentDTOPut> Equipments { get; set; }
        public List<PostClientDTO> clients { get; set; }
        public List<GetEmployeesByGymId> employees { get; set; }
        public List<GymGetSubscriptionTierDTO> subscriptiontiers { get; set; }
    }

    public class PostClientDTO
    {
        public int ClientID { get; set; }
        // Forgein Key
        public int GymID { get; set; }
        // Forgein Key
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public bool InGym { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }

        //N.P

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
        public List<GymSupplementDTO>? Supplements { get; set; }
    }
}

