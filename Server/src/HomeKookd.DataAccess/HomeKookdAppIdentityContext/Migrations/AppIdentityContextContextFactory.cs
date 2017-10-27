using System.IO;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HomeKookd.DataAccess.HomeKookdMainContext
{
    public class AppIdentityContextContextFactory : IDesignTimeDbContextFactory<AppIdentityContext>
    {
        public AppIdentityContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppIdentityContext>();
            var connectionString = configuration.GetConnectionString("IdentityDb");
            builder.UseSqlServer(connectionString);
            return new AppIdentityContext(builder.Options);
        }
    }
}