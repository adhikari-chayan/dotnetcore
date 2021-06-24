using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralsightDemo
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
            var myOptions = Configuration.GetSection("MyMiddlewareOptionsSection");

            services.Configure<MyMiddlewareOptions>(myOptions);

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync($"Hello from component one!{Environment.NewLine}");
                await next.Invoke();
                await context.Response.WriteAsync($"Hello from component one AGAIN!{Environment.NewLine}");
            });

            app.UseMyMiddleware();

            app.Map("/mymapbranch", (appBuilder) =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    await next.Invoke();
                });

                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"Greetings from my Map Branch!{Environment.NewLine}");
                });
            });

            app.MapWhen(context => context.Request.Query.ContainsKey("querybranch"), (appBuilder) =>
              {
                  appBuilder.Run(async (context) =>
                  {
                     await context.Response.WriteAsync($"You have arrived at your Map When branch{Environment.NewLine}");
                  });
              });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello World! {context.Items["message"]} {Environment.NewLine}");
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
