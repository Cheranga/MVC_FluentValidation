using System;
using Autofac;
using FluentValidation;

namespace MVC_FluentValidation_Intermediate.Validators
{
    public class AutofacValidationFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public AutofacValidationFactory(IContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = _container.ResolveKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}