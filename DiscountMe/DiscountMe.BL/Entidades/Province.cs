using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Province : EntidadBase {
        #region Primitive Properties

        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public Country Country { get; set; }

        public List<City> Cities { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<ProvinceValidator, Province>(this);
        }
    }
}