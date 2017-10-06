using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;

namespace MVC_FluentValidation_Intermediate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //
            // Setup Autofac DI
            var container = AutofacConfig.RegisterComponents();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //
            // Setup fluent validation
            //
            FluentValidationApiConfig.Register(container);
        }
    }
}
