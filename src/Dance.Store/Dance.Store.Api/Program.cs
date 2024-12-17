using Dance.Store.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApplicationBuilder();
builder.WebHost.UseUrls("http://*:50002");
var app = builder.Build();

app.ConfigureApplication();

app.Run();