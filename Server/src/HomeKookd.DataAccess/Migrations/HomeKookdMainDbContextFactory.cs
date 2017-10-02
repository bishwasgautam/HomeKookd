using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HomeKookd.DataAccess.HomeKookdMainContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HomeKookd.DataAccess.Migrations
{
    public class HomeKookdMainDbContextFactory : IDesignTimeDbContextFactory<HomeKookdMainDataContext>
    {
        public HomeKookdMainDataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<HomeKookdMainDataContext>();
            var connectionString = configuration.GetConnectionString("HomeKookd.main");
            builder.UseSqlServer(connectionString);
            return new HomeKookdMainDataContext(builder.Options);
        }
    }
}
