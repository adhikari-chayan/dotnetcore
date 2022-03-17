using MinimalApiRefactored.Models;
using MinimalApiRefactored.SecretSauce;

var builder = WebApplication.CreateBuilder(args);


//Configure Services

//The typeof(Customer) is a pointer towards assembly scanning. Asks the system to pick all classes implementing IEndpointDefinition and belonging to the assemby same as Customer class
builder.Services.AddEndpointDefinitions(typeof(Customer));

var app = builder.Build();

//Configure Middleware
app.UseEndpointDefinitions();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();




