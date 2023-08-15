namespace GYM_Management_System.Models.DTOs
{
    public class GetGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        //NP
        public List<Employee>? Employees { get; set; }
        public List<Client>? Clients { get; set; }
        public List<Supplement>? Supplements { get; set; }
        public List<GymEquipment>? GymEquipments { get; set; }
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
