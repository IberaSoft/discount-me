using System.Data.Entity;
using DiscountMe.BL;
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

        #region DbSet Properties

        public DbSet<Address> Address { get; set; }

        public DbSet<Advertiser> Advertisers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<DBVersion> DBVersions { get; set; }

        public DbSet<DiscountCategory> DiscountCategories { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<UserPreferences> UserPreferences { get; set; }

        public DbSet<User> Users { get; set; }

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