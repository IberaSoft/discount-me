using System.Collections.Generic;

namespace DiscountMe.BL.ViewModels {
    public class AdvertiserAdministracionViewModel {
        public List<Discount> GetDiscounts;
        public PagingInfo PagingInfo { get; set; }
    }
}