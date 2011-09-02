using FluentValidation;

namespace DiscountMe.BL.Validaciones {
    public class UserPreferencesValidator : AbstractValidator<UserPreferences>{
        public UserPreferencesValidator() {
            RuleFor(u => u.User).NotNull();
        }
    }
}