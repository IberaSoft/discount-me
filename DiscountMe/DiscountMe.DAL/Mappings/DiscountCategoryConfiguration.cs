using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class DiscountCategoryConfiguration : EntityTypeConfiguration<DiscountCategory> {
        public DiscountCategoryConfiguration() {
            ToTable("DiscountCategories");
            HasKey(dc => dc.Id).Property(dc => dc.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(dc => dc.Name).IsRequired();
            Property(dc => dc.Description).IsOptional();
            HasMany(dc => dc.Discounts).WithRequired(dc => dc.DiscountCategory).Map(k => k.MapKey("DiscountCategoryId"));
        }
    }
}