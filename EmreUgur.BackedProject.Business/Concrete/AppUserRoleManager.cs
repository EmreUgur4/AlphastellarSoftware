using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        private readonly IGenericDal<AppUserRole> _genericDal;

        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
