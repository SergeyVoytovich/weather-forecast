using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherForecast.ApplicationLayer;
using WeatherForecast.Common.ApplicationLayer;
using WeatherForecast.Common.Data;
using WeatherForecast.Data.OpenWeather;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Presentation.Api
{
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; set; }

        private const string PolicyName = "CorsPolicy";

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add cors policies
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });
            
            services.AddControllers();
            
            // Add addition services
            services.AddHttpClient();
            services.AddSingleton<IOpenWeatherConfig>(provider =>
                new OpenWeatherConfig(Configuration.GetSection("OpenWeatherMap")["ApiKey"]));
            services.AddSingleton<IDatabase, OpenWeatherDatabase>();
            services.AddSingleton<IApplication, Application>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(PolicyName);
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}