using FluentValidation;

namespace DiscountMe.BL {
    public class ProvinceValidator : AbstractValidator<Province> {
        public ProvinceValidator() {
            RuleFor(p => p.Name).NotEmpty().WithMessage("El nombre de la provincia no puede estar vacío");
            RuleFor(p => p.Country).NotNull().WithMessage("El país no puede estar vacío");
        }
    }
}