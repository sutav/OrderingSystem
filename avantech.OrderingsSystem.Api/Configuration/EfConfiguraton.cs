using avantech.OrderingSystem.Data.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace avantech.OrderingsSystem.Api.Configuration
{
    public static class EfConfiguration
    {
        public static IServiceCollection AddEntityFrameworkConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {            
            services.AddDbContext<ProductApiContext>(
                (sp, options) =>
                {
                    var sqlConnection = new SqlConnection(configuration.GetConnectionString("OrderingSystem"));

                    options.UseSqlServer(sqlConnection, opt =>
                    {
                        opt.EnableRetryOnFailure();
                        opt.CommandTimeout(120);
                    });

                    if (webHostEnvironment.IsDevelopment())
                        options.EnableSensitiveDataLogging();
                });

            return services;
        }
    }
}
