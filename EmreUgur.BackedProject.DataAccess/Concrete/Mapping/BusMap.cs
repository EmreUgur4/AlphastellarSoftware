using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class BusMap : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
