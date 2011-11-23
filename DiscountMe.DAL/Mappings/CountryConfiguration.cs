using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class CountryConfiguration : EntityTypeConfiguration<Country> {
        public CountryConfiguration() {
            ToTable("Countries");
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired();
            HasMany(c => c.Provinces).WithRequired(p => p.Country).Map(k => k.MapKey("CountryId"));
        }
    }
}