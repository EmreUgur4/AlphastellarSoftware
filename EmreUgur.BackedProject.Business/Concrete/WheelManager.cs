using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class WheelManager : GenericManager<Wheel>, IWheelService
    {
        private readonly IGenericDal<Wheel> _genericDal;

        public WheelManager(IGenericDal<Wheel> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
