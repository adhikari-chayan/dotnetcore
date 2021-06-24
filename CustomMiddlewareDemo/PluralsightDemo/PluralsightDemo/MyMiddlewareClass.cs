using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace PluralsightDemo
{
    public class MyMiddlewareClass
    {
        RequestDelegate _next;
        ILoggerFactory _loggerFactory;
        MyMiddlewareOptions _middlewareOptions;
        public MyMiddlewareClass(RequestDelegate next, ILoggerFactory loggerFactory,IOptions<MyMiddlewareOptions> options)
        {
            
            _next = next;
            _loggerFactory = loggerFactory;
            _middlewareOptions = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var logger = _loggerFactory.CreateLogger("My Own Logger");
            logger.LogInformation("My middleware class is handling the request");

            //Passing data between middleware components. Whateveris set here, will be accessed in the terminal middleware component in pipeline(check Startup.cs)

            context.Items["message"] = "The weather is great today";

            await context.Response.WriteAsync($"My middleware class is handling the request{Environment.NewLine}");
            
            await context.Response.WriteAsync($"{_middlewareOptions.OptionOne}{Environment.NewLine}");
            
            await _next.Invoke(context);
            
            await context.Response.WriteAsync($"My middleware class has completed handling the request{Environment.NewLine}");

        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddlewareClass>();
        }
    }

    public class MyMiddlewareOptions
    {
        public string OptionOne { get; set; }
    }

}
