using Dance.Subscription.Application.Exceptions;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace Dance.Subscription.Api.Middleware;

public class HttpGlobalExceptionHandler(IHostEnvironment environment) : IExceptionHandler
{
    private readonly IHostEnvironment _environment = environment ?? throw new ArgumentNullException(nameof(environment));

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var task = exception switch
        {
            ValidationException validationException => HandleValidationException(httpContext, validationException),
            NotFoundException notFoundException => HandleNotFoundException(httpContext, notFoundException),
            _ => HandleError(httpContext, exception)
        };

        await task;

        return true;
    }

    private Task HandleNotFoundException(HttpContext context, NotFoundException notFoundException)
    {
        return context.WriteErrorAsync(HttpStatusCode.NotFound,
            _environment.IsDevelopment() ? notFoundException.Message : "Resource not found");
    }

    private Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            validationException.Errors.Select(x => x.ErrorMessage).ToArray());
    }

    private Task HandleError(HttpContext context, Exception exception)
    {
        return context.WriteErrorAsync(HttpStatusCode.InternalServerError,
            _environment.IsDevelopment() ? exception.Message : "An unexpected error occured");
    }
}