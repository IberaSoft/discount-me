using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class AddressConfiguration : EntityTypeConfiguration<Address> {
        public AddressConfiguration() {
            ToTable("Addresses");
            HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Street).IsRequired();
            Property(a => a.PostalCode).IsRequired();
            HasRequired(a => a.City).WithMany(c => c.Addresses).Map(k => k.MapKey("CityId"));
            HasMany(ad => ad.Advertisers).WithRequired(adv => adv.Address).Map(k => k.MapKey("AddressId"));
        }    
    }
}