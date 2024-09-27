using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace ProjectManagement.Infrastructure.Security;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                                Exception exception,
                                                CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        var details = new ProblemDetails()
        {
            Type = exception.GetType().Name,
            Detail = exception.Message,
            Title = exception.GetType().Name,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
        };
            
        details.Status = exception switch
        {
            ApplicationException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            NullReferenceException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var response = JsonSerializer.Serialize(details);
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(response, cancellationToken);

        return true;
    }
}
