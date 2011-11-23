using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Country : EntidadBase {
        #region Primitive Properties

        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public List<Province> Provinces { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<CountryValidator, Country>(this);
        }
    }
}