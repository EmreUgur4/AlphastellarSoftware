using EmreUgur.BackedProject.DataAccess.Concrete.Context;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        private readonly DatabaseContext _context;

        public EfAppUserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            return await _context.AppUsers.Join(_context.AppUserRoles, u => u.Id, ur => ur.AppUserId,
                (user, userRole) => new
                {
                    user = user,
                    userRole = userRole
                }).Join(_context.AppRoles, two => two.userRole.AppRoleId, r => r.Id, (twoTable, role) => new
                {
                    user = twoTable.user,
                    userRole = twoTable.userRole,
                    role = role
                }).Where(x => x.user.UserName == userName).Select(x => new AppRole
                {
                    Id = x.role.Id,
                    Name = x.role.Name
                }).ToListAsync();
        }
    }
}
