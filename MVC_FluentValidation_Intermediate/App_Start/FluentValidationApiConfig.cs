using System.Web.Mvc;
using Autofac;
using FluentValidation.Mvc;
using MVC_FluentValidation_Intermediate.Validators;

namespace MVC_FluentValidation_Intermediate
{
    public class FluentValidationApiConfig
    {
        public static void Register(IContainer container)
        {
            if (container == null)
            {
                return;
            }

            var modelValidatorProvider = new FluentValidationModelValidatorProvider(new AutofacValidationFactory(container));
            ModelValidatorProviders.Providers.Add(modelValidatorProvider);
        }
    }
}