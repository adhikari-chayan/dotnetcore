using CacheStackExchangeRedis.BackgroundTasks;
using CacheStackExchangeRedis.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheStackExchangeRedis
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
            //services.AddSingleton<ICacheService, InMemoryCacheService>();

            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection")));

            services.AddSingleton<ICacheService, RedisCacheService>();

            services.AddHostedService<RedisSubscriber>();

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
