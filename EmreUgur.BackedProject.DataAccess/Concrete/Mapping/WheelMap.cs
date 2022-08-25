using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class WheelMap : IEntityTypeConfiguration<Wheel>
    {
        public void Configure(EntityTypeBuilder<Wheel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Cars).WithOne(x => x.Wheel).HasForeignKey(x => x.WheelId);
        }
    }
}
