using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //added to use in-memory cache
            services.AddMemoryCache();

            //added to use Redis cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });
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
