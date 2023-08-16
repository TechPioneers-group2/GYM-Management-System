namespace GYM_Management_System.Models
{
    public class Supplement
    {
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }


        // Navigation props
        public List<GymSupplement> Supplements { get; set; }

    }
}
