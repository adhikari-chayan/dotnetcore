using AuthenticationAndValidationDemo.Models;
using AuthenticationAndValidationDemo.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


//Configure Services
builder.Services.AddSingleton<ICustomerRepository,CustomerRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the bearer scheme",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });
    x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {new OpenApiSecurityScheme{Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        } },new List<string>() }
    });
});

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Customer>());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

var app = builder.Build();

//Configure Middleware

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

//Approach1-- > Adding attribute to lambda
//app.MapGet("/customers",
//[ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
//(ICustomerRepository repo) =>
//{
//    return Results.Ok(repo.GetAll());
//});

//Approach2-->Using Fluent method
app.MapGet("/customers", (ICustomerRepository repo) =>
 {
     return Results.Ok(repo.GetAll());
 })
    //.RequireAuthorization()        //Commenting as we want to apply authorization for all endpoints
    .AllowAnonymous() // Only this endpoint allows anonymous users
    .Produces<IEnumerable<Customer>>();


app.MapGet("/customers/{id}", (ICustomerRepository repo, Guid id) =>
{
    var customer = repo.GetById(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/customers", (ICustomerRepository repo, IValidator<Customer> validator,Customer customer) =>
{
    var validationResult = validator.Validate(customer);

    if (!validationResult.IsValid)
    {
        var errors = new { errors = validationResult.Errors.Select(x => x.ErrorMessage) };
        return Results.BadRequest(errors);
    }

    repo.Create(customer);
    return Results.Created($"/customers/{customer.Id}", customer);
})
    .AllowAnonymous();

app.MapPut("/customers/{id}", (ICustomerRepository repo, Guid id, Customer updatedCustomer) =>
{
    var customer = repo.GetById(id);
    if (customer is null)
    {
        return Results.NotFound();
    }

    repo.Update(updatedCustomer);
    return Results.Ok(updatedCustomer);
});

app.MapDelete("/customers/{id}", (ICustomerRepository repo, Guid id) =>
{
    repo.Delete(id);
    return Results.Ok();
});

app.Run();

