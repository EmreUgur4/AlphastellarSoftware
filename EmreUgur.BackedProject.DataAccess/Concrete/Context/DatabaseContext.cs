using EmreUgur.BackedProject.DataAccess.Concrete.Mapping;
using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new BoatMap());
            modelBuilder.ApplyConfiguration(new BusMap());
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new HeadlightMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new WheelMap());


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Headlight> Headlights { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Wheel> Wheels { get; set; }
    }
}
