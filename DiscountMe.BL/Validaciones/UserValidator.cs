using FluentValidation;

namespace DiscountMe.BL {
    public class UserValidator : AbstractValidator<User> {
        public UserValidator() {
            RuleFor(u => u.Name).NotEmpty().WithMessage("El nombre no puede estar vacío");
            RuleFor(u => u.Surname).NotEmpty().WithMessage("El apellido no puede estar vacío");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("El nombre de usuario no puede estar vacío");
            RuleFor(u => u.Password).NotEmpty().WithMessage("La contraseña no puede estar vacía").Length(8, 30).WithMessage("La contraseña debe contener al menos 8 caracteres");
            RuleFor(u => u.Email).NotEmpty().WithMessage("El email no puede estar vacío").EmailAddress().WithMessage("La dirección de email no es correcta");
            RuleFor(u => u.CreateDate);
            RuleFor(u => u.LastLoginDate);
            RuleFor(u => u.NewPasswordRequestedDate);
        }
    }
}