using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CourseLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Global Level Cache Header Configuration
            services.AddHttpCacheHeaders((expirationModelOptions)=>
            {
                expirationModelOptions.MaxAge = 60;
                expirationModelOptions.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
            },
            (validationModelOptions) =>
            {
                validationModelOptions.MustRevalidate = true;
            }
            );

            services.AddResponseCaching();

            services.AddControllers(setupAction =>
            {
                //setting this true ensures that if the client requests for a formatter not supported by the API, it will return status code 406 instead of the default
                setupAction.ReturnHttpNotAcceptable = true;
                //Adding to the list of output formatters. We have a shortcut to do this as well
                //setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());

                setupAction.CacheProfiles.Add("240SecondsCacheProfile", new CacheProfile() { Duration = 240 });


            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            })
            .AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setupAction=>{
                setupAction.InvalidModelStateResponseFactory = context =>
                {

                    /*
                     Here we see we have configured a new InvalidModelStateResponseFactory, and that one isn't used when returning the ValidationProblem from our controller action. It's only used when input is validated via the model binder and the ModelState on an API controller isn't valid anymore due to that.

                    But this can be fixed-->Check how we override the ValidationProblem method from ControllerBase class to resolve this in CoursesController
                     */
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = "https://courselibrary.com/modelvalidationproblem",
                        Title = "One or more model validation errors occurred.",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = "See the errors property for details.",
                        Instance = context.HttpContext.Request.Path
                    };

                    problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);
                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
                    
            });

            //Adding more configuration to the MVC pipeline
            //We include this to fix the  "No output formatter was found for content types application/ vnd.marvin .hateoas +json" issue
            /*
             
              On the MvcOptions object we have access to when calling into AddController, we find a collection of output formatters. Each of these output formatters has a supported media types collection. We can add media types, like application/ vnd.marvin.hateoas+json, to the supported media type collection of the output formatter we want to handle this media type. But which formatter is that? If we look at what we change right after calling into AddControllers, we see that we added the NewtonsoftJson formatters. These are the formatters that handle JSON input and output instead of the built-in JSON formatters. The reason is that they are more feature-rich. They are, for example, still required if you want to support JSON patch documents, which our API does. 
              
            The issue is that these formatters are added after we can access the MvcOption's OutputFormatters list. So if we look for a NewtonsoftJson output formatter on the OutputFormatters collection at that time, it won't be there. But no worries, we can work around that. We can configure these MvcOptions afterwards as well. 
            
            By calling into configure on the services collection and passing through MvcOptions as the type, we can configure them again. So on this config object's OutputFormatters collection, we look for the an output formatter of type NewtonsoftJsonOutputFormatter. If one exists, we add application/ vnd.marvin.hateoas +json to its SupportedMediaTypes collection. Note that doing this adds support for this media type application-wide. The other way around exists as well. We can restrict certain actions, controllers, or even the full application to certain media types.
             
             */
            services.Configure<MvcOptions>(config =>
            {
                var newtonsoftJsonOutputFormatter = config.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();
                if (newtonsoftJsonOutputFormatter != null)
                {
                    newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.marvin.hateoas+json");
                }
            });


            //Register PropertyMappingService
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();

            //Register PropertyCheckerService
            services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();

            services.AddDbContext<CourseLibraryContext>(options =>
            {
                options.UseSqlServer(@"server=U0169352-TPL-A;Database=CourseLibraryDB;Trusted_Connection=True;");
            });
        }   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            //Marvin.Cache.Headers middleware to generate the ETags is already in place.
            //The resource caching middleware is disabled as we are using the Marvin.Cache.Headers midldleware
            
            //app.UseResponseCaching();

            app.UseHttpCacheHeaders();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
