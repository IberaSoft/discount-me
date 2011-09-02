using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Province : EntidadBase {
        #region Primitive Properties

        public virtual string Name { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Country Country { get; set; }

        public virtual List<City> Cities { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<ProvinceValidator, Province>(this);
        }
    }
}