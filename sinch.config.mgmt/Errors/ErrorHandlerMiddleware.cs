using Microsoft.AspNetCore.Mvc;
using ServiceRegister;
using ApplicationMime = System.Net.Mime.MediaTypeNames.Application;

namespace Sinch.Config.Mgmt.Errors;

[SingletonService(implementationAsSelf: true)]
public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context).ConfigureAwait(false);
        }
        catch (MockException mockException)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = ApplicationMime.Json;

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Detail = mockException.Message,
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
            });
        }
        catch (DocumentNotFoundException documentNotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = ApplicationMime.Json;

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Detail = documentNotFoundException.Message,
                Status = StatusCodes.Status404NotFound,
                Title = "Document Not Found",
            });
        }
        catch (BadHttpRequestException badHttpRequestException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = ApplicationMime.Json;

            var baseException = badHttpRequestException.GetBaseException();

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Detail = baseException.Message,
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad HTTP Request",
            });
        }
    }
}
