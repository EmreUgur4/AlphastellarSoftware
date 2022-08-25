using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.SurName).HasMaxLength(150);

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
