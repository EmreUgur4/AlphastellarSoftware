using EmreUgur.BackedProject.DTO.Interfaces;

namespace EmreUgur.BackedProject.DTO.Dtos
{
    public class CarListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public bool IsHeadlightOn { get; set; }

        public int VehicleId { get; set; }
        public VehicleListDto Vehicle { get; set; }

        public int WheelId { get; set; }
        public WheelListDto Wheel { get; set; }

        public int HeadlightId { get; set; }
        public HeadlightListDto Headlight { get; set; }
    }
}
