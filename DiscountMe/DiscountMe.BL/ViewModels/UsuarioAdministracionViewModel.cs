using System.Collections.Generic;

namespace DiscountMe.BL.ViewModels {
    public class UsuarioAdministracionViewModel {
        public IList<Discount> GetLatestDiscounts;
        public IList<DiscountCategory> Categories;
        public IList<Advertiser> Advertisers;
        public IList<UserPreferences> UserPreferences;
    }
}