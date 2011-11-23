using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Rol : EntidadBase {
        #region Primitive Properties

        public string RoleName { get; set; }

        public string Description { get; set; }

        #endregion

        #region Navigation Properties

        public List<User> Users { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<RolValidator, Rol>(this);
        }
    }
}