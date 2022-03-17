using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProtobuDemo.Services;
using StackExchange.Redis;

namespace ProtobuDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

     
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection")));

            services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            services.Decorate<IWeatherForecastService, CachedWeatherForecastService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProtobuDemo", Version = "v1" });
            });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProtobuDemo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
