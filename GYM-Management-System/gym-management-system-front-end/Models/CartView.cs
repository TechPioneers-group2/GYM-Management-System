using GYM_Management_System.Models;
using System.ComponentModel;

namespace gym_management_system_front_end.Models
{
    public class CartView
    {

        /*[DisplayName("Supplement ID ")]
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string? imageURL { get; set; }*/
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Total { get; set; }

        public List<CartSupp>? CartSupp { get; set; }
    }
}
