using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class ColorManager : GenericManager<Color>, IColorService
    {
        private readonly IGenericDal<Color> _genericDal;

        public ColorManager(IGenericDal<Color> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
