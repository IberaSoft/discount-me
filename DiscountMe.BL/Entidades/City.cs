using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class City : EntidadBase {
        #region Primitive Properties

        public virtual string Name { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Province Province { get; set; }

        public virtual List<Address> Addresses { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<CityValidator, City>(this);
        }
    }
}