using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class HeadlightManager : GenericManager<Headlight>, IHeadlightService
    {
        private readonly IGenericDal<Headlight> _genericDal;

        public HeadlightManager(IGenericDal<Headlight> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
