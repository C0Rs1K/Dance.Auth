using Dance.Auth.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebApplicationBuilder();

var app = builder.Build();

app.ConfigureApplicationPipeline();

app.Run();
