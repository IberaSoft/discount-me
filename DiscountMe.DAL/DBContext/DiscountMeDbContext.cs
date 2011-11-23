using System.Data.Entity;
using DiscountMe.DAL.DBContext;
using DiscountMe.Dal.Mappings;

namespace DiscountMe.DAL {
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public class DiscountMeDbContext : DbContext {
        #region Constructors

        /// <summary>
        /// Initializes a new DiscountMeDbContext object using the connection string found in the 'DiscountMeDbContext' section of the application configuration file.
        /// </summary>
        public DiscountMeDbContext() : base("name=DiscountMeDbContext") {
            Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new AdvertiserConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new DBVersionConfiguration());
            modelBuilder.Configurations.Add(new DiscountCategoryConfiguration());
            modelBuilder.Configurations.Add(new DiscountConfiguration());
            modelBuilder.Configurations.Add(new ProvinceConfiguration());
            modelBuilder.Configurations.Add(new RolConfiguration());
            modelBuilder.Configurations.Add(new UserPreferencesConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            Database.SetInitializer(new InitializerIfNotExits());
            Database.SetInitializer(new InitializerIfModelChanges());
            base.OnModelCreating(modelBuilder);
        }
    }
}