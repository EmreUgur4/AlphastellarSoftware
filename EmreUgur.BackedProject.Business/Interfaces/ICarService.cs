using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Interfaces
{
    public interface ICarService : IGenericService<Car>
    {
        Task<List<Car>> GetCarsByColorAsync(string color);
    }
}
