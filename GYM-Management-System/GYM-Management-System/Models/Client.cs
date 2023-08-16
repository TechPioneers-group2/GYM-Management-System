using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYM_Management_System.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        // Forgein Key
        public int GymID { get; set; }
        // Forgein Key
        
        public string Name { get; set; }
        public bool InGym { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }

        //N.P
       //[ForeignKey("GymID")]
        public Gym? Gym { get; set; }
        
        public int SubscriptionTierID { get; set; }
        public SubscriptionTier SubscriptionTierOBJ { get; set; }
    }
}
