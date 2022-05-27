using Microsoft.AspNetCore.HttpOverrides;
using NotificationBroker.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();

builder.Services.AddHostedService<NotificationBroker.Services.NotificationBroker>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
                        {
                            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                        });

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapHub<ChatHub>("/chat-hub"); });

app.Run();