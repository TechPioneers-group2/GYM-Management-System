namespace GYM_Management_System.Models
{
    public class GymSupplement
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }

        // Navigation props
        public Gym? Gym { get; set; }
        public Supplement? Supplement { get; set; }
    }
}
