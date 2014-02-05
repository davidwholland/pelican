using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Pelican.Models;

namespace Pelican.App_Start
{
    public class DependenciesConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<IdentityManager>().As<IIdentityManager>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}