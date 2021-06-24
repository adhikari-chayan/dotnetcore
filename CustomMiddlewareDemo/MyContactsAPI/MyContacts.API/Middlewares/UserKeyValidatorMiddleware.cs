using Microsoft.AspNetCore.Http;
using MyContacts.Providers.Repository;
using System.Threading.Tasks;

namespace MyContacts.API.Middlewares
{
    public class UserKeyValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        public UserKeyValidatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IContactsAsyncRepository contactsRepo)
        {
            if (!context.Request.Headers.Keys.Contains("user-key"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("User Key is missing");
                return;
            }
            else
            {
                if(!contactsRepo.CheckValidUserKey(context.Request.Headers["user-key"]))
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    await context.Response.WriteAsync("Invalid User Key");
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
