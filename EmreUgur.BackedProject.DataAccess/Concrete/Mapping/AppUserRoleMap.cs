using EmreUgur.BackedProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmreUgur.BackedProject.DataAccess.Concrete.Mapping
{
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new { x.AppUserId, x.AppRoleId }).IsUnique();
        }
    }
}
