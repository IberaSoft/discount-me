using FluentValidation;

namespace DiscountMe.BL {
    public class CountryValidator : AbstractValidator<Country> {
        public CountryValidator() {
            RuleFor(c => c.Name).NotEmpty().WithMessage("El nombre del país no puede estar vacío");
        }
    }
}