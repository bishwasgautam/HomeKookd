using System.Text;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;

namespace HomeKookd.API.Identity
{
    public static class IdentityConfig
    {

        public static void SetupIdentity(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppIdentityContext>()
                .AddDefaultTokenProviders();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters.ValidIssuer = Configuration["JwtAuthToken:Issuer"];
                    options.TokenValidationParameters.ValidAudience = Configuration["JwtAuthToken:Audience"];
                    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"]));
                    options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    options.TokenValidationParameters.ValidateLifetime = true;
                });

            services.AddAuthorization(options =>
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
        }
    }
}
