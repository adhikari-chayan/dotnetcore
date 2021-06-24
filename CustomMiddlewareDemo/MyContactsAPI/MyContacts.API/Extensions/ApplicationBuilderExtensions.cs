using Microsoft.AspNetCore.Builder;
using MyContacts.API.Middlewares;

namespace MyContacts.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorMiddleware>();
            return app;
        }
    }
}
