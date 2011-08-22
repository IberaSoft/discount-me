using System;
using FluentValidation;
using StructureMap;

namespace DiscountMe.DependencyResolution {
    public class SMValidatorFactory : ValidatorFactoryBase {
        public override IValidator CreateInstance(Type validatorType) {
            return ObjectFactory.TryGetInstance(validatorType) as IValidator;
        }
    }
}