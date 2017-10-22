using System.Reflection;
using Autofac;
using HomeKookd.Infrastructure.Authentication;
using HomeKookd.Repositories;
using HomeKookd.Services;
using Module = Autofac.Module;

namespace HomeKookd.API.DiModules
{
    public class AssemblyWiseRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterAssemblyTypes(typeof(UserRepository).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Converter"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Services
            builder.RegisterAssemblyTypes(typeof(UserService).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Infrastructure
            builder.RegisterAssemblyTypes(typeof(AuthenticationContext).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Context"))
                .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
