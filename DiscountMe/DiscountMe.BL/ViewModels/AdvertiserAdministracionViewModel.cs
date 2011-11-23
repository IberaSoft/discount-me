using System.Collections.Generic;

namespace DiscountMe.BL.ViewModels
{
    public class AdvertiserAdministracionViewModel
    {
        public IList<Discount> GetLatestDiscounts;
        public IList<DiscountCategory> Categories;
        public IList<Advertiser> Advertisers;
        public List<Discount> Discounts;
    }
}