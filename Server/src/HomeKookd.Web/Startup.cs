using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HomeKookd.API.DiModules;
using HomeKookd.API.Filters;
using HomeKookd.API.Identity;
using HomeKookd.Common;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using HomeKookd.DataAccess.HomeKookdMainContext;
using HomeKookd.DependencyResolution;
using HomeKookd.Repositories.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Web;


namespace HomeKookd.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(Infrastructure.Logging.ILogger<>), typeof(Infrastructure.Logging.Logger<>));

            var mainDbConnectionString = Configuration.GetConnectionString(Keys.ConnectionStrings.HomeKookdMain);
            services.AddDbContext<HomeKookdMainDataContext>(options => options.UseSqlServer(mainDbConnectionString));
            SetupIdentityDatabase(services);

            services.SetupIdentity(Configuration);

            // Add framework services.
            services.AddMvc(mvc =>
                {
                    mvc.Filters.AddService(typeof(UnitOfWorkFilterAttribute));
                    mvc.SslPort = 44352;
                    mvc.Filters.Add(new RequireHttpsAttribute());
                })
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore //ignores any exception due to cyclic references in EF entities
                );

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMaps)));

            //services.AddSwaggerGen(c =>
            //{
            //    c.OperationFilter<AddRequiredHeaderParameter>();
            //    c.SchemaFilter<AddSchemaExamples>();
            //    c.DescribeAllEnumsAsStrings();
            //    c.SwaggerDoc("v1", new Info { Title = "Eoi Hub API", Version = "v1" });
            //});

            var builder = new ContainerBuilder();

            builder.RegisterInstance(Configuration).As<IConfiguration>().SingleInstance();
            builder.RegisterCustomModule<AssemblyWiseRegistrationModule>()
                .AddServices(services);

            builder.RegisterType<UnitOfWorkFilterAttribute>().AsSelf().InstancePerLifetimeScope();

            DependencyResolver.SetContainer(builder.BuildDependencies());

            return new AutofacServiceProvider(DependencyResolver.ApplicationContainer);
        }

        public virtual void SetupIdentityDatabase(IServiceCollection services)
        {
            var identityDbConnectionString = Configuration.GetConnectionString(Keys.ConnectionStrings.HomekookdIdentity);
            services.AddDbContext<AppIdentityContext>(options => options.UseSqlServer(identityDbConnectionString));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStaticFiles();
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowAllOrigins");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            app.AddNLogWeb();

            LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");

            LogManager.Configuration.Variables["connectionString"] =
             
                Configuration.GetConnectionString(Keys.ConnectionStrings.HomekookdLogging);

            LogManager.Configuration.Variables["configDir"] = Configuration["Logging:LogFilePath"];


            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeKookd API");
            //});

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppIdentityContext>();
                EnsureDatabaseCreated(dbContext);
            }
        }

        public virtual void EnsureDatabaseCreated(AppIdentityContext dbContext)
        {
            // run Migrations
            dbContext.Database.Migrate();
        }
    }
}
