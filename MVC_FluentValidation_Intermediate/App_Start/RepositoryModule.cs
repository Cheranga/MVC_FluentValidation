using Autofac;
using MVC_FluentValidation_Intermediate.Repositories;

namespace MVC_FluentValidation_Intermediate
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModelRepository>().As<IRegisterModelRepository>();
        }
    }
}