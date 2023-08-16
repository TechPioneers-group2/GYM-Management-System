namespace GYM_Management_System.Models.DTOs
{
    public class GetSupplementDTO
    {
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }


        // Navigation props
        // public List<GymSupplement>? Supplements { get; set; }
    }


    public class UpdateSupplementDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
