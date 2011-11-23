using System.Data.Entity;

namespace DiscountMe.DAL.DBContext {
    public class InitializerIfNotExits : CreateDatabaseIfNotExists<DiscountMeDbContext> {
        protected override void Seed(DiscountMeDbContext context) {
            InitTables.CreateCountries(context);
            InitTables.CreateProvinces(context);
            InitTables.CreateCities(context);
            InitTables.CreateDiscountCategories(context);
            InitTables.CreateFakeMapPositions(context);
            InitTables.CreateFakeMapPositions(context);
            InitTables.CreateFakeAddress(context);
            InitTables.CreateFakeAdvertiser(context);
            InitTables.CreateFakeDiscounts(context);
        }
    }
}