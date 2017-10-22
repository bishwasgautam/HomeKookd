using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HomeKookd.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HomeKookd.DataAccess.HomeKookdMainContext;
using HomeKookd.DependencyResolution;


namespace HomeKookd.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            AutoMapperConfig.RegisterProfiles();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(mvc => mvc.Filters.AddService(typeof(UnitOfWorkFilterAttribute)))
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore //ignores any exception due to cyclic references in EF entities
                );

            var mainDbConnectionString = Configuration.GetConnectionString("HomeKookd.main");
            services.AddDbContext<HomeKookdMainDataContext>(options => options.UseSqlServer(mainDbConnectionString));

            //services.AddSwaggerGen(c =>
            //{
            //    c.OperationFilter<AddRequiredHeaderParameter>();
            //    c.SchemaFilter<AddSchemaExamples>();
            //    c.DescribeAllEnumsAsStrings();
            //    c.SwaggerDoc("v1", new Info { Title = "Eoi Hub API", Version = "v1" });
            //});

            var builder = new ContainerBuilder();
            builder.AddServices(services);

            DependencyResolver.SetContainer(builder.BuildDependencies());

            return new AutofacServiceProvider(DependencyResolver.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeKookd API");
            });

            app.UseMvc();
        }
    }
}
