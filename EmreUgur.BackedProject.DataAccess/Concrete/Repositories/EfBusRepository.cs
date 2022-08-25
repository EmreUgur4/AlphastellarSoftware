using EmreUgur.BackedProject.DataAccess.Concrete.Context;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Repositories
{
    public class EfBusRepository : EfGenericRepository<Bus>, IBusDal
    {
        private readonly DatabaseContext _context;

        public EfBusRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Bus>> GetBusesByColorAsync(string color)
        {
            return await _context.Buses.Include(x => x.Vehicle).ThenInclude(x => x.Color).Where(x => x.Vehicle.Color.Name.ToLower() == color.ToLower()).ToListAsync();
        }
    }
}
