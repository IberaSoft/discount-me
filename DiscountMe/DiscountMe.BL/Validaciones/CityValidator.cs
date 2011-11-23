using FluentValidation;

namespace DiscountMe.BL {
    public class CityValidator : AbstractValidator<City> {
        public CityValidator() {
            RuleFor(c => c.Name).NotEmpty().WithMessage("El nombre de la ciudad no puede estar vacío");
            RuleFor(c => c.Province).NotNull().WithMessage("La provincia no puede estar vacía");
        }
    }
}