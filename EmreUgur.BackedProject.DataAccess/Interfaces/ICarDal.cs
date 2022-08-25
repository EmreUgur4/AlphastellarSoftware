using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.DataAccess.Interfaces
{
    public interface ICarDal : IGenericDal<Car>
    {
        Task<List<Car>> GetCarsByColorAsync(string color);
    }
}
