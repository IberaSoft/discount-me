using FluentValidation;

namespace DiscountMe.BL {
    public class UserValidator : AbstractValidator<User> {
        public UserValidator() {
            RuleFor(u => u.Name).NotEmpty().WithMessage("El nombre no puede estar vac�o");
            RuleFor(u => u.Surname).NotEmpty().WithMessage("El apellido no puede estar vac�o");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("El nombre de usuario no puede estar vac�o");
            RuleFor(u => u.Password).NotEmpty().WithMessage("La contrase�a no puede estar vac�a").Length(8, 30).WithMessage("La contrase�a debe contener al menos 8 caracteres");
            RuleFor(u => u.Email).NotEmpty().WithMessage("El email no puede estar vac�o").EmailAddress().WithMessage("La direcci�n de email no es correcta");
            RuleFor(u => u.CreateDate);
            RuleFor(u => u.LastLoginDate);
            RuleFor(u => u.NewPasswordRequestedDate);
        }
    }
}