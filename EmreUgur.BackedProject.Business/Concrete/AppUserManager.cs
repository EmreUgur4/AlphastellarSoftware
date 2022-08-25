using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.Common.Helpers;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.DTO.Dtos;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _appUserDal = appUserDal;
        }

        public async Task<bool> CheckPasswordAsync(AppUserSignInDto appUserSignInDto)
        {
            var appUser = await _genericDal.GetAsync(x => x.UserName == appUserSignInDto.UserName);

            return appUser.Password == PasswordHelper.PasswordEnCrypt(appUserSignInDto.Password) ? true : false;
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            return await _genericDal.GetAsync(x => x.UserName == userName);
        }

        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            return await _appUserDal.GetRolesByUserNameAsync(userName);
        }
    }
}
