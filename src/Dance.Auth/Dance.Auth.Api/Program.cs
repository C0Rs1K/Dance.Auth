using Dance.Auth.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebApplicationBuilder();
builder.WebHost.UseUrls("http://*:50001");
var app = builder.Build();

app.ConfigureApplicationPipeline();

app.Run();
