using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class Vehicle : ITable
    {
        public int Id { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        public List<Car> Cars { get; set; }
        public List<Bus> Buses { get; set; }
        public List<Boat> Boats { get; set; }
    }
}
