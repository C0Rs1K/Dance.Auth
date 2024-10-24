using Dance.Subscription.Application.Commands.StudentSubscription;
using Dance.Subscription.Application.Handlers.Commands;
using Dance.Subscription.Application.Handlers.Commands.StudentSubscription;
using Hangfire;

namespace Dance.Subscription.Api.Configuration;

public static class ApplicationExtension
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.ConfigureSwagger()
            .ConfigureHangfire();
        app.UseExceptionHandler(_ => { })
            .UseRouting()
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseAuthorization()
            .UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            .UseEndpoints(endpoints => endpoints.MapControllers());

        return app;
    }

    private static WebApplication ConfigureHangfire(this WebApplication app)
    {
        app.UseHangfireDashboard();

        RecurringJob.AddOrUpdate<DeleteExpiredSubscriptionHandler>("ExpiredSubscriptionsDeletion",
            handler => handler.Handle(new DeleteExpiredSubscriptionCommand(), CancellationToken.None),
            Cron.Daily);

        return app;
    }

    private static WebApplication ConfigureSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}