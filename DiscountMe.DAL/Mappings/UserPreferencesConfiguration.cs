using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.Dal.Mappings {
    class UserPreferencesConfiguration: EntityTypeConfiguration<UserPreferences> {
        public UserPreferencesConfiguration() {
            ToTable("UserPreferences");
            HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(p => p.User).WithMany(u => u.Preferences).Map(k => k.MapKey("UserId"));
            HasRequired(p => p.AdvertiserPreferred);
            HasRequired(p => p.DiscountCategoryPreferred);
        }
    }
}