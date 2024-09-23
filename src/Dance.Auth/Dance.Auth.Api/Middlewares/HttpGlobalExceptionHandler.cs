using System.Net;
using Dance.Auth.BusinessLogic.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace Dance.Auth.Api.Middlewares;

public class HttpGlobalExceptionHandler(IHostEnvironment environment) : IExceptionHandler
{
    private readonly IHostEnvironment _environment = environment ?? throw new ArgumentNullException(nameof(environment));

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var task = exception switch
        {
            ValidationException validationException => HandleValidationException(httpContext, validationException),
            BadRequestException badRequestException => HandleBadRequestException(httpContext, badRequestException),
            UnauthorizedAccessException unauthorizedException => HandleUnauthorizedException(httpContext, unauthorizedException),
            _ => HandleError(httpContext, exception)
        };

        await task;

        return true;
    }

    private Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            validationException.Errors.Select(x => x.ErrorMessage).ToArray());
    }

    private Task HandleBadRequestException(HttpContext context, BadRequestException badHttpRequestException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            _environment.IsDevelopment() ? badHttpRequestException.Message : "Bad request");
    }

    private Task HandleUnauthorizedException(HttpContext context, UnauthorizedAccessException unauthorizedException)
    {
        return context.WriteErrorAsync(HttpStatusCode.Unauthorized,
            _environment.IsDevelopment() ? unauthorizedException.Message : "Unauthorized");
    }

    private Task HandleError(HttpContext context, Exception exception)
    {
        return context.WriteErrorAsync(HttpStatusCode.InternalServerError,
            _environment.IsDevelopment() ? exception.Message : "An unexpected error occured");
    }
}