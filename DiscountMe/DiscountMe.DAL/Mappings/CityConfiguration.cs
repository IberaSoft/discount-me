using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class CityConfiguration : EntityTypeConfiguration<City> {
        public CityConfiguration() {
            ToTable("Cities");
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired();
            HasRequired(c => c.Province).WithMany(p => p.Cities).Map(k => k.MapKey("ProvinceId"));
            HasMany(c => c.Addresses).WithRequired(a => a.City).Map(k => k.MapKey("CityId"));
        }
    }
}