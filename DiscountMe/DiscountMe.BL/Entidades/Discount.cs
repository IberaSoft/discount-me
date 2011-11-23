using System;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Discount : EntidadBase {
        #region Primitive Properties

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public double? DiscountPercent { get; set; }

        public int? StockQuantity { get; set; }

        public int? StockWarningLevel { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? UntilDate { get; set; }

        public bool? IsPublished { get; set; }

        public string Comment { get; set; }

        #endregion

        #region Navigation Properties

        public DiscountCategory DiscountCategory { get; set; }

        public Advertiser Advertiser { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<DiscountValidator, Discount>(this);
        }
    }
}