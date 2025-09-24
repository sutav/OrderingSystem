using avantech.OrderingSystem.Data.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avantech.OrderingSystem.Services.Configuration
{

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {         
            services.AddScoped<IProductRepository, ProductRepository>();
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
