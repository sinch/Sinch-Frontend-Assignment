using Microsoft.AspNetCore.Mvc;
using Sinch.Config.Mgmt.Models;
using Sinch.Config.Mgmt.Persistence;

namespace Sinch.Config.Mgmt;

public static class EnviromentEndpoints
{
    public static IEndpointRouteBuilder MapEnviromentEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/v1/applications/{applicationId}/environments", ListEnviroments)
            .Produces<SinchPageListResponse<EnviromentResponse>>(StatusCodes.Status200OK)
            .WithTags("Environments");

        builder
            .MapPost("/api/v1/applications/{applicationId}/environments", CreateEnviroment)
            .Produces<SinchResponse<EnviromentResponse>>(StatusCodes.Status200OK)
            .WithTags("Environments");

        builder
            .MapPut("/api/v1/applications/{applicationId}/environments/{environmentId}", UpdateEnviroment)
            .Produces<SinchResponse<EnviromentResponse>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Environments");

        builder
            .MapDelete("/api/v1/applications/{applicationId}/environments/{environmentId}", DeleteEnviroment)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Environments");

        return builder;
    }

    internal static async Task<IResult> ListEnviroments(
        [FromServices] IEnvironmentRepository enviromentRepository,
        [FromRoute] Guid applicationId,
        [FromQuery] string? searchTerm,
        [FromQuery] int take = 100,
        [FromQuery] int skip = 0,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            var items = await enviromentRepository.GetAsync(applicationId, take, skip, cancellationToken).ConfigureAwait(false);
            var count = await enviromentRepository.GetCountAsync(applicationId, cancellationToken).ConfigureAwait(false);

            var response = new SinchPageListResponse<EnviromentResponse>(
                ResponseMapper.Map(items),
                count);

            return Results.Ok(response);
        }
        else
        {
            var items = await enviromentRepository.SearchAsync(applicationId, searchTerm, take, skip, cancellationToken).ConfigureAwait(false);
            var count = await enviromentRepository.GetCountAsync(applicationId, searchTerm, cancellationToken).ConfigureAwait(false);

            var response = new SinchPageListResponse<EnviromentResponse>(
                ResponseMapper.Map(items),
                count);

            return Results.Ok(response);
        }
    }

    internal static async Task<IResult> CreateEnviroment(
        [FromServices] IEnvironmentRepository enviromentRepository,
        [FromRoute] Guid applicationId,
        [FromBody] EnviromentRequest enviroment,
        CancellationToken cancellationToken = default)
    {
        enviroment = enviroment with { ApplicationId = applicationId };

        var model = await enviromentRepository
            .AddAsync(enviroment.ToPersistenceModel(), cancellationToken)
            .ConfigureAwait(false);

        return Results.Ok(new SinchResponse<EnviromentResponse>(ResponseMapper.Map(model)));
    }

    internal static async Task<IResult> UpdateEnviroment(
        [FromServices] IEnvironmentRepository enviromentRepository,
        [FromRoute] Guid applicationId,
        [FromRoute] Guid environmentId,
        [FromBody] EnviromentRequest enviroment,
        CancellationToken cancellationToken = default)
    {
        enviroment = enviroment with { ApplicationId = applicationId };

        var model = await enviromentRepository
            .UpdateAsync(enviroment.ToPersistenceModel(environmentId), cancellationToken)
            .ConfigureAwait(false);

        return Results.Ok(new SinchResponse<EnviromentResponse>(ResponseMapper.Map(model)));
    }

    internal static async Task<IResult> DeleteEnviroment(
        [FromServices] IEnvironmentRepository enviromentRepository,
        [FromRoute(Name = "applicationId")] Guid _,
        [FromRoute] Guid environmentId,
        CancellationToken cancellationToken = default)
    {
        await enviromentRepository
            .DeleteAsync(environmentId, cancellationToken)
            .ConfigureAwait(false);

        return Results.NoContent();
    }
}
