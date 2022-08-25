using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasMany(x => x.Cars).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
            builder.HasMany(x => x.Boats).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
            builder.HasMany(x => x.Buses).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
        }
    }
}
