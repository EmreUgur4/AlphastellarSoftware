using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class BoatManager : GenericManager<Boat>, IBoatService
    {
        private readonly IGenericDal<Boat> _genericDal;
        private readonly IBoatDal _boatDal;

        public BoatManager(IGenericDal<Boat> genericDal, IBoatDal boatDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _boatDal = boatDal;
        }

        public async Task<List<Boat>> GetBoatsByColorAsync(string color)
        {
            return await _boatDal.GetBoatsByColorAsync(color);
        }
    }
}
