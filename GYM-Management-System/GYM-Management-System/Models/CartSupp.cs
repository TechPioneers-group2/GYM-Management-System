using Stripe;

namespace GYM_Management_System.Models
{
    public class CartSupp
    {
        public int Id { get; set; }
        public int SupplementId { get; set; }
        public CartViewModel? Cart { get; set; }

        public string UserId { get; set; }
        public Supplement? supplement { get; set; }

        public int Quantity { get; set; }
    }
}
