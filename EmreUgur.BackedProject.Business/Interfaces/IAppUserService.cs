using EmreUgur.BackedProject.DTO.Dtos;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(AppUserSignInDto appUserSignInDto);
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
