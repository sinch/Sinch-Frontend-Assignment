namespace Sinch.Config.Mgmt;

public static class HealthEndpoints
{
    public static IEndpointRouteBuilder MapHealthEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/health/ping", Ping)
            .Produces(StatusCodes.Status204NoContent)
            .WithTags("Health");

        return builder;
    }

    internal static IResult Ping() => Results.NoContent();
}
