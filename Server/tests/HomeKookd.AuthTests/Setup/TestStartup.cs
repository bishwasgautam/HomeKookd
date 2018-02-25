using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using HomeKookd.API;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext;
using Microsoft.Extensions.Configuration;

namespace TokenAuthWebApiCore.Server.IntegrationTest.Setup
{
	public class TestStartup : Startup
	{
		public TestStartup(IConfiguration configuration) : base(configuration)
		{
		}
		public override void SetupIdentityDatabase(IServiceCollection services)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			var connectionString = connectionStringBuilder.ToString();
			var connection = new SqliteConnection(connectionString);

			services
			  .AddEntityFrameworkSqlite()
			  .AddDbContext<AppIdentityContext>(
				options => options.UseSqlite(connection)
			  );
		}

		public override void EnsureDatabaseCreated(AppIdentityContext dbContext)
		{
			dbContext.Database.OpenConnection(); 
			dbContext.Database.EnsureCreated();
		}
		
	}
}
