using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gym_management_system_front_end.Models.Models
{
    public class Client
    {
        // Primary Key
        public string UserId { get; set; }
        public int ClientID { get; set; }

        // Forgein Key
        //both are composite key
        public int GymID { get; set; }
        public string Name { get; set; }
        public bool InGym { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        public int SubscriptionTierID { get; set; }

        //N.P
       //[ForeignKey("GymID")]
        public Gym? Gym { get; set; }
        
        public SubscriptionTier SubscriptionTierOBJ { get; set; }
    }
}
