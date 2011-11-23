using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class AdvertiserConfiguration : EntityTypeConfiguration<Advertiser> {
        public AdvertiserConfiguration() {
            ToTable("Advertisers");
            HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).IsRequired();
            Property(a => a.Surname).IsRequired();
            Property(a => a.UserName).IsRequired();
            Property(a => a.CompanyName).IsRequired();
            Property(a => a.Website).IsOptional();
            Property(a => a.Description).IsOptional();
            Property(a => a.PrimaryPhone).IsRequired();
            Property(a => a.PrimaryFax).IsOptional();
            Property(a => a.Comment).IsOptional();
            Property(ad => ad.Cif).IsRequired();
            Property(ad => ad.Email).IsRequired();
            Property(ad => ad.Password).IsRequired();
            Property(ad => ad.PasswordSalt).IsRequired();
            Property(ad => ad.CreateDate).IsRequired();
            Property(ad => ad.LastModifiedDate).IsOptional();
            Property(ad => ad.LastLoginDate).IsOptional();
            Property(ad => ad.LastLoginIp).IsOptional();
            Property(ad => ad.IsActivated).IsRequired();
            Property(ad => ad.IsLockedOut).IsRequired();
            Property(ad => ad.LastLockedOutDate).IsOptional();
            Property(ad => ad.NewPasswordKey).IsOptional();
            Property(ad => ad.NewPasswordRequestedDate).IsOptional();
            Property(ad => ad.NewEmailKey).IsOptional();
            Property(ad => ad.Latitude).IsRequired();
            Property(ad => ad.Longitude).IsRequired();
            HasRequired(a => a.Address).WithMany(add => add.Advertisers).Map(k => k.MapKey("AddressId"));
            HasMany(a => a.Discounts).WithRequired(d => d.Advertiser).Map(k => k.MapKey("AdvertiserId"));
        }
    }
}