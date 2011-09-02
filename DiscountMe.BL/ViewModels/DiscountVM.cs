using System.Collections.Generic;

namespace DiscountMe.BL.ViewModels {
    public class DiscountVM {
        public Discount Discount { get; set; }

        public List<DiscountCategory> DiscountCategories { get; set; }

        public int SelectedCategoryId { get; set; }
    }
}