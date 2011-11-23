using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class RolConfiguration : EntityTypeConfiguration<Rol> {
        public RolConfiguration() {
            ToTable("Roles");
            HasKey(r => r.Id).Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.RoleName).IsRequired();
            Property(r => r.Description);
            HasMany(r => r.Users).WithMany(u => u.Roles).Map(k => k.ToTable("UserRoles").MapLeftKey("UserId").MapRightKey("RolId"));
        }
    }
}