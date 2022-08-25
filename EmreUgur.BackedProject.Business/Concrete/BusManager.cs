using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class BusManager : GenericManager<Bus>, IBusService
    {
        private readonly IGenericDal<Bus> _genericDal;
        private readonly IBusDal _busDal;

        public BusManager(IGenericDal<Bus> genericDal, IBusDal busDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _busDal = busDal;
        }

        public async Task<List<Bus>> GetBusesByColorAsync(string color)
        {
            return await _busDal.GetBusesByColorAsync(color);
        }
    }
}
