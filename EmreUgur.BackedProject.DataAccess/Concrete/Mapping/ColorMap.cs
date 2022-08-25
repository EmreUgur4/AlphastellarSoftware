using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.Vehicles).WithOne(x => x.Color).HasForeignKey(x => x.ColorId);
        }
    }
}
