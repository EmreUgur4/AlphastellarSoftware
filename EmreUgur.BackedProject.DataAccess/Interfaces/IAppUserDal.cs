using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
