using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class City : EntidadBase {
        #region Primitive Properties

        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public Province Province { get; set; }

        public List<Address> Addresses { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<CityValidator, City>(this);
        }
    }
}