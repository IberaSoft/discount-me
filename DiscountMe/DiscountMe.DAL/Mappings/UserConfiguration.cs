using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class UserConfiguration : EntityTypeConfiguration<User> {
        public UserConfiguration() {
            ToTable("Users");
            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Name).IsRequired();
            Property(u => u.Surname).IsRequired();
            Property(u => u.UserName).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.Email).IsRequired();
            Property(u => u.CreateDate).IsRequired();
            Property(u => u.NewPasswordRequestedDate);
            Property(u => u.PasswordSalt).IsRequired();
            Property(u => u.LastModifiedDate).IsOptional();
            Property(u => u.LastLoginDate).IsOptional();
            Property(u => u.LastLoginIp).IsOptional();
            Property(u => u.IsActivated).IsRequired();
            Property(u => u.IsLockedOut).IsRequired();
            Property(u => u.LastLockedOutDate).IsOptional();
            Property(u => u.NewPasswordKey).IsOptional();
            Property(u => u.NewPasswordRequestedDate).IsOptional();
            Property(u => u.NewEmailKey).IsOptional();
            HasMany(u => u.Roles).WithMany(r => r.Users).Map(k => k.ToTable("UserRoles").MapLeftKey("UserId").MapRightKey("RolId"));
            HasMany(u => u.Preferences).WithRequired(p => p.User).Map(k => k.MapKey("UserId"));
        }
    }
}