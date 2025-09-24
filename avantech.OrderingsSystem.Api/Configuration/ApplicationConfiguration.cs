using avantech.OrderingSystem.Data;
using avantech.OrderingSystem.Data.Data;
using avantech.OrderingSystem.Services.Contracts;
using avantech.OrderingSystem.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avantech.OrderingsSystem.Api.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenericDbSet, GenericDbSet>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static ILogger<T> GetMicrosoftLogger<T>(this Serilog.ILogger serilogLogger)
        {
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            loggerFactory.AddSerilog(serilogLogger);
            return loggerFactory.CreateLogger<T>();
        }
    }
}
