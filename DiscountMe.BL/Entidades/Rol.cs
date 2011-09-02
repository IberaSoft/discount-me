using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Rol : EntidadBase {
        #region Primitive Properties

        public virtual string RoleName { get; set; }

        public virtual string Description { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<User> Users { get; set; }

        public virtual List<Advertiser> Advertisers { get; set; }

        #endregion

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<RolValidator, Rol>(this);
        }
    }
}