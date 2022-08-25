using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class Color : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
