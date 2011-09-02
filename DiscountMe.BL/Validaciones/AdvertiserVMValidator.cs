using DiscountMe.BL.ViewModels;
using FluentValidation;

namespace DiscountMe.BL {
    public class AdvertiserVMValidator : AbstractValidator<AdvertiserVM> {
        private const string Mensaje = "Elija su posición en el mapa";
        public AdvertiserVMValidator() {
            RuleFor(a => a.Street).NotEmpty().WithMessage(Mensaje);
            RuleFor(a => a.City).NotEmpty().WithMessage(Mensaje);
            RuleFor(a => a.PostalCode).NotEmpty().WithMessage(Mensaje);
            RuleFor(a => a.Advertiser).SetValidator(new AdvertiserValidator());
            RuleFor(a => a.Latitude).NotEmpty().WithMessage(Mensaje);
            RuleFor(a => a.Longitude).NotEmpty().WithMessage(Mensaje);
        }
    }
}