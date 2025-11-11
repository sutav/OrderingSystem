using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avantech.OrderingsSystem.Api.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
              {
                  options.Authority = $"https://{configuration["Auth0:Domain"]}";
                  options.Audience = configuration["Auth0:Audience"];
              });

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
