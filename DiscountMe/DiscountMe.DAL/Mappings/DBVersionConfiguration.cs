using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public class DBVersionConfiguration : EntityTypeConfiguration<DBVersion> {
        public DBVersionConfiguration() {
            ToTable("DBVersion");
            HasKey(v => v.Id).Property(v => v.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.Name);
            Property(v => v.Value);
        }
    }
}