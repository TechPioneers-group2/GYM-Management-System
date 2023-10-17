using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
