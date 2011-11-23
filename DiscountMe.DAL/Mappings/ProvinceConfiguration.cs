using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class ProvinceConfiguration : EntityTypeConfiguration<Province> {
        public ProvinceConfiguration() {
            ToTable("Provinces");
            HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired();
            HasRequired(p => p.Country).WithMany(c => c.Provinces).Map(k => k.MapKey("CountryId"));
            HasMany(p => p.Cities).WithRequired(c => c.Province).Map(k => k.MapKey("ProvinceId"));
        }
    }
}