using System.Collections.Generic;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class Address : EntidadBase {

        #region Primitive Properties

        public string Street { get; set; }

        public string PostalCode { get; set; }

        #endregion

        #region Navigation Properties

        public User User { get; set; }

        public City City { get; set; }

        public List<Advertiser> Advertisers { get; set; }

        #endregion

        #region Inherited from EntidadBase
        
        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<AddressValidator, Address>(this);
        }

        #endregion
    }
}