using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class Boat : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }

        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
