using FluentValidation;

namespace DiscountMe.BL {
    public class DiscountCategoryValidator : AbstractValidator<DiscountCategory> {
        public DiscountCategoryValidator() {
            RuleFor(dc => dc.Name);
            RuleFor(dc => dc.Description);
        }
    }
}