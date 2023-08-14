namespace GYM_Management_System.Models
{
    public class Supplement
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }

        //N.P
        public Gym Gym { get; set; }

    }
}
