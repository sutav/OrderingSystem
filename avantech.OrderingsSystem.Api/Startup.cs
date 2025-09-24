using avantech.OrderingsSystem.Api.Configuration;
using avantech.OrderingSystem.Services.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avantech.OrderingsSystem.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // https://sgwiki.sgfleet.com/display/bsys/sgfleet.Api.Fuel#sgfleet.Api.Fuel-Servicesandappconfiguration
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddEntityFrameworkConfiguration(Configuration, _webHostEnvironment);
            services.AddApplicationConfiguration(Configuration);
        }
        public void Configure(IApplicationBuilder app,
                              IHostEnvironment hostEnvironment,
                              IConfiguration configuration)
        {
            bool isDev = hostEnvironment.IsDevelopment();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
             
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapGet("/", () => Results.Ok())
                         .AllowAnonymous(); // Handle keep alive requests from Azure
            });

        }
    }
}
        
