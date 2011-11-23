using System;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace DiscountMe.BL {
    // Homenaje a sevententh: http://fluentvalidation.codeplex.com/discussions/212235?ProjectName=fluentvalidation
    // Basado en el trabajo de Prajeesh Prathap: http://blogsprajeesh.blogspot.com/2009/11/fluent-validation-wpf-implementation.html
    public class ValidationHelper {
        public static ValidationResult Validate<T, K>(K entity) where T : IValidator<K>, new() where K : class {
            IValidator<K> validator = new T();
            return validator.Validate(entity);
        }

        public static string GetError(ValidationResult result) {
            var validationErrors = new StringBuilder();
            foreach (var validationFailure in result.Errors) {
                validationErrors.Append(validationFailure.ErrorMessage);
                validationErrors.Append(Environment.NewLine);
            }
            return validationErrors.ToString();
        }
    }
}