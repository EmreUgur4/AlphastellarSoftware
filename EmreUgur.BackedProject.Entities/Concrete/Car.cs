using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class Car : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public bool IsHeadlightOn { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int WheelId { get; set; }
        public Wheel Wheel { get; set; }

        public int HeadlightId { get; set; }
        public Headlight Headlight { get; set; }
    }
}
