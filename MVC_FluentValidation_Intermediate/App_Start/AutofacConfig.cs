using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using MVC_FluentValidation_Intermediate.Validators;

namespace MVC_FluentValidation_Intermediate
{
    public class AutofacConfig
    {
        public static IContainer RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();
            builder.RegisterModule<ValidationModule>();
            builder.RegisterModule<RepositoryModule>();

            var container = builder.Build();

            return container;
        }
    }
}