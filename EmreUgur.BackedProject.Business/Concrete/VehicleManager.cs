using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class VehicleManager : GenericManager<Vehicle>, IVehicleService
    {
        private readonly IGenericDal<Vehicle> _genericDal;

        public VehicleManager(IGenericDal<Vehicle> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
