using Microsoft.OpenApi.Models;
using MinimalApiRefactored.SecretSauce;

namespace MinimalApiRefactored.EndpointDefinitions;

public class SwaggerEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetDocsShow.Structured.Custom v1"));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinimalApiRefactored", Version = "v1" });
        });
    }
}
