using System.Text.RegularExpressions;
using FluentValidation;

namespace DiscountMe.BL {
    public class AddressValidator : AbstractValidator<Address> {
        public AddressValidator() {
            RuleFor(a => a.Street).NotEmpty();
            RuleFor(a => a.PostalCode).Must(BeAValidPostalCode).WithMessage("El c�digo postal no es v�lido");
        }

        public bool BeAValidPostalCode(string codigoPostal) {
            return !string.IsNullOrWhiteSpace(codigoPostal) && Regex.Match(codigoPostal, @"^\d{5}$").Success;
        }
    }
}