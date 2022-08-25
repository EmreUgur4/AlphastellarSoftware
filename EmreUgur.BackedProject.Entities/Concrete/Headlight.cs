using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class Headlight : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }

    }
}
