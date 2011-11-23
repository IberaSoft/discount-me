using System.Data.Entity;
using DiscountMe.DAL.DBContext;

namespace DiscountMe.DAL {
    public class InitializerIfModelChanges : DropCreateDatabaseIfModelChanges<DiscountMeDbContext> {
        protected override void Seed(DiscountMeDbContext context) {
            InitTables.CreateCountries(context);
            InitTables.CreateProvinces(context);
            InitTables.CreateCities(context);
            InitTables.CreateDiscountCategories(context);
            InitTables.CreateFakeMapPositions(context);
            InitTables.CreateFakeAddress(context);
            InitTables.CreateFakeAdvertiser(context);
            InitTables.CreateFakeDiscounts(context);
        }
    }
}