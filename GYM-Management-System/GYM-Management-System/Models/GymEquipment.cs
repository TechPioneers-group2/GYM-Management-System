namespace GYM_Management_System.Models
{
    public class GymEquipment
    {
        public int GymEquipmentID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }

        //N.P
        public Gym Gym { get; set; }
    }
}
