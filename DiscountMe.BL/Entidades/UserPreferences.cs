using DiscountMe.BL.Validaciones;
using FluentValidation.Results;

namespace DiscountMe.BL {
    public class UserPreferences : EntidadBase {
        public User User { get; set; }

        public virtual DiscountCategory DiscountCategoryPreferred { get; set; }

        public virtual Advertiser AdvertiserPreferred { get; set; }
        
        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<UserPreferencesValidator, UserPreferences>(this);
        }
    }
}