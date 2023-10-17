using System.ComponentModel;

namespace gym_management_system_front_end.Models
{
    public class SupplementViewModel
    {
        [DisplayName("Supplement ID ")]
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

    }
}
