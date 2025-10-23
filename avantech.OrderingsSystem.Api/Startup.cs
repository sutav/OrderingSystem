using avantech.OrderingsSystem.Api.Configuration;
using avantech.OrderingSystem.Services.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


namespace avantech.OrderingsSystem.Api
{
    public class Startup
    {
        private string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins(Configuration.GetSection("Cors").Get<string[]>() ?? [])
                            .AllowAnyMethod()
                            .AllowAnyHeader() ;
                    });
            });
                    
        }
        public void Configure(IApplicationBuilder app,
                              IHostEnvironment hostEnvironment,
                              IConfiguration configuration)
        {
            bool isDev = hostEnvironment.IsDevelopment();
          
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            //app.UseAuthentication();
            app.UseStaticFiles();  
           
            app.UseSwagger();
            if (isDev)
            {
                app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.yaml", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapGet("/", () => Results.Ok())
                         .AllowAnonymous(); // Handle keep alive requests from Azure
            });
            
         
        }
    }
}
        
