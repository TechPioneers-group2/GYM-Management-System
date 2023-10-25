

using gym_management_system_front_end.Models;

namespace gym_management_system_front_end
{
    public class EquipmentViewModel

    {
        public int GymEquipmentID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }
        public string? PhotoUrl { get; set; }
        public List<GymIDDTO>? GymIDsNames { get; set; }

    }
}
