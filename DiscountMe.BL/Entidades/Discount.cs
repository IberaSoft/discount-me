using System;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Discount : EntidadBase {
        #region Primitive Properties

        public virtual string ProductName { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal? Price { get; set; }

        public virtual double? DiscountPercent { get; set; }

        public virtual int? StockQuantity { get; set; }

        public virtual int? StockWarningLevel { get; set; }

        public virtual DateTime? FromDate { get; set; }

        public virtual DateTime? UntilDate { get; set; }

        public virtual bool? IsPublished { get; set; }

        public virtual string Comment { get; set; }

        #endregion

        #region Navigation Properties

        public virtual DiscountCategory DiscountCategory { get; set; }

        public virtual Advertiser Advertiser { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<DiscountValidator, Discount>(this);
        }
    }
}