using FluentValidation.Results;

namespace DiscountMe.BL.ViewModels {
    public class AdvertiserVM : EntidadBase {
        public Advertiser Advertiser { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Latitude { get; set; }
        
        public string Longitude { get; set; }

        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<AdvertiserVMValidator, AdvertiserVM>(this);
        }
    }
}