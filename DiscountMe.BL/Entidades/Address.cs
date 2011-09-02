using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Address : EntidadBase {

        #region Primitive Properties

        public virtual string Street { get; set; }

        public virtual string PostalCode { get; set; }

        #endregion

        #region Navigation Properties

        public virtual City City { get; set; }

        public virtual List<Advertiser> Advertisers { get; set; }

        #endregion

        #region Inherited from EntidadBase
        
        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<AddressValidator, Address>(this);
        }

        #endregion
    }
}