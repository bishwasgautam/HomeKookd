using System;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace HomeKookd.DependencyResolution
{
    public static class DependencyResolver
    {
        public static ContainerBuilder RegisterCustomModule<TModule>(this ContainerBuilder builder)
            where TModule : IModule, new()
        {
            if (builder == null)
                builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            return builder;
        }

        public static ContainerBuilder AddServices(this ContainerBuilder builder, IServiceCollection services)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            builder.Populate(services);

            return builder;
        }

        public static IContainer BuildDependencies(this ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("Builder cannot be null");
            }

            return builder.Build();
        }

        public static void SetContainer(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("Container cannot be null");

            if (ApplicationContainer != null)
                throw new DuplicateContainerInitializationException(
                    "Duplicate init request: ApplicationContainer can be intialized only once");

            ApplicationContainer = container;
        }

        public static IContainer ApplicationContainer { get; private set; }

    }

    public class DuplicateContainerInitializationException : Exception
    {
        public new string Message { get; set; }
        public DuplicateContainerInitializationException(string msg)
        {
            Message = msg;
        }
    }
}
