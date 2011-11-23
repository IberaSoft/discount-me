using System;
using FluentValidation;

namespace DiscountMe.BL {
    public class DiscountValidator : AbstractValidator<Discount> {
        public DiscountValidator(){
            RuleFor(d => d.ProductName).NotEmpty().WithMessage("El nombre del producto no puede estar vacío");
            RuleFor(d => d.Description);
            RuleFor(d => d.Price).NotEmpty().WithMessage("El precio del producto no puede estar vacío")
                .GreaterThanOrEqualTo((decimal)0.01).WithMessage(string.Format("El precio debe ser como mínimo de {0:C}", 0.01));
            RuleFor(d => d.DiscountPercent);
            RuleFor(d => d.StockQuantity);
            RuleFor(d => d.StockWarningLevel);
            RuleFor(d => d.FromDate).GreaterThanOrEqualTo(DateTime.Now.Date).When(d => d.FromDate != null)
                .WithMessage("La fecha de inicio de la oferta debe ser posterior a la fecha actual");
            RuleFor(d => d.UntilDate).GreaterThanOrEqualTo(x => x.FromDate.Value).When(x => x.FromDate != null && x.UntilDate != null)
                .WithMessage("La fecha de finalización de la oferta debe ser posterior a la fecha de inicio de la misma");
            RuleFor(d => d.IsPublished);
            RuleFor(d => d.Advertiser).NotNull().WithMessage("La oferta debe estar asociada a un anunciante");
            RuleFor(d => d.Comment);
        }
    }
}