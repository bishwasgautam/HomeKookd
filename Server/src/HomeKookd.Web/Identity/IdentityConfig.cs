using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
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

            services.AddCors(config => {
                config.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowCredentials().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); 
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["JwtAuthToken:Issuer"],
                        ValidateIssuer = true,
                        ValidAudience = Configuration["JwtAuthToken:Audience"],
                        ValidateAudience = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(Configuration["JwtAuthToken:SecurityKey"])),
                        ValidateIssuerSigningKey = false,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };

                });

        }
    }
}
