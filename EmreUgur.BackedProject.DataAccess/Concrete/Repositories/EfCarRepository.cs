using EmreUgur.BackedProject.DataAccess.Concrete.Context;
using EmreUgur.BackedProject.DataAccess.Interfaces;
using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Repositories
{
    public class EfCarRepository : EfGenericRepository<Car>, ICarDal
    {
        private readonly DatabaseContext _context;

        public EfCarRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsByColorAsync(string color)
        {
            return await _context.Cars.Include(x => x.Vehicle).ThenInclude(x => x.Color).Where(x => x.Vehicle.Color.Name.ToLower() == color.ToLower()).ToListAsync();
        }
    }
}
