using FluentValidation;

namespace DiscountMe.BL {
    public class RolValidator : AbstractValidator<Rol> {
        public RolValidator() {
            RuleFor(r => r.RoleName).NotEmpty().WithMessage("El nombre del rol no puede estar vacío");
            RuleFor(r => r.Description);
        }
    }
}