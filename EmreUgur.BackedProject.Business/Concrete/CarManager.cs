using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class CarManager : GenericManager<Car>, ICarService
    {
        private readonly IGenericDal<Car> _genericDal;
        private readonly ICarDal _carDal;

        public CarManager(IGenericDal<Car> genericDal, ICarDal carDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _carDal = carDal;
        }

        public async Task<List<Car>> GetCarsByColorAsync(string color)
        {
            return await _carDal.GetCarsByColorAsync(color);
        }
    }
}
