using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class DiscountCategory : EntidadBase {
        #region Primitive Properties
        
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<Discount> Discounts { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<DiscountCategoryValidator, DiscountCategory>(this);
        }
    }
}