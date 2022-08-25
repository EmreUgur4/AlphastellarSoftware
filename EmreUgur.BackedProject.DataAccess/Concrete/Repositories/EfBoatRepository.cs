using EmreUgur.BackedProject.DataAccess.Concrete.Context;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Repositories
{
    public class EfBoatRepository : EfGenericRepository<Boat>, IBoatDal
    {
        private readonly DatabaseContext _context;

        public EfBoatRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Boat>> GetBoatsByColorAsync(string color)
        {
            return await _context.Boats.Include(x => x.Vehicle).ThenInclude(x => x.Color).Where(x => x.Vehicle.Color.Name.ToLower() == color.ToLower()).ToListAsync();
        }
    }
}
