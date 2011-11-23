using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class DiscountConfiguration : EntityTypeConfiguration<Discount> {
        public DiscountConfiguration() {
            ToTable("Discounts");
            HasKey(d => d.Id).Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(d => d.ProductName);
            Property(d => d.Description);
            Property(d => d.Price);
            Property(d => d.DiscountPercent);
            Property(d => d.StockQuantity);
            Property(d => d.StockWarningLevel);
            Property(d => d.FromDate);
            Property(d => d.UntilDate);
            Property(d => d.IsPublished);
            Property(d => d.Comment);
            HasRequired(d => d.DiscountCategory).WithMany(dc => dc.Discounts).Map(k => k.MapKey("DiscountCategoryId"));
            HasRequired(d => d.Advertiser).WithMany(a => a.Discounts).Map(k => k.MapKey("AdvertiserId"));
        }
    }
}