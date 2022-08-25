using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class HeadlightMap : IEntityTypeConfiguration<Headlight>
    {
        public void Configure(EntityTypeBuilder<Headlight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Cars).WithOne(x => x.Headlight).HasForeignKey(x => x.HeadlightId);
        }
    }
}
