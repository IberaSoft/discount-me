using DiscountMe.BL.ViewModels;
using FluentValidation;

namespace DiscountMe.BL.Validaciones {
    public class LogOnVMValidator : AbstractValidator<LogOnVM> {
        public LogOnVMValidator() {
            RuleFor(l => l.UserName)
                .NotEmpty().WithMessage("El nombre del usuario no puede estar vacío");
            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("La contraseña no puede estar vacía")
                .Length(8,200).WithMessage("La contraseña debe tener al menos 8 caracteres");
        }
    }
}