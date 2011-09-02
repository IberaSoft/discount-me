using DiscountMe.BL.Validaciones;
using FluentValidation.Results;

namespace DiscountMe.BL.ViewModels {
    public class LogOnVM : EntidadBase {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
        
        public override ValidationResult SelfValidate() {
            return ValidationHelper.Validate<LogOnVMValidator, LogOnVM>(this);
        }
    }
}