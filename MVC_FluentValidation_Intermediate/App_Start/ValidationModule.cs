using Autofac;
using FluentValidation;
using MVC_FluentValidation_Intermediate.Models;
using MVC_FluentValidation_Intermediate.Validators;

namespace MVC_FluentValidation_Intermediate
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModelValidator>()
                .Keyed<IValidator>(typeof (RegisterModel))
                .As<IValidator>();
        }
    }
}