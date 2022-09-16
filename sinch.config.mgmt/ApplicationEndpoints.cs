using Microsoft.AspNetCore.Mvc;
using Sinch.Config.Mgmt.Models;
using Sinch.Config.Mgmt.Persistence;

namespace Sinch.Config.Mgmt;

public static class ApplicationEndpoints
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/v1/applications", ListApplications)
            .Produces<SinchPageListResponse<ApplicationResponse>>(StatusCodes.Status200OK)
            .WithTags("Applications");

        builder
            .MapPost("/api/v1/applications", CreateApplication)
            .Produces<SinchResponse<ApplicationResponse>>(StatusCodes.Status200OK)
            .WithTags("Applications");

        builder
            .MapPut("/api/v1/applications/{applicationId}", UpdateApplication)
            .Produces<SinchResponse<ApplicationResponse>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Applications");

        builder
            .MapDelete("/api/v1/applications/{applicationId}", DeleteApplication)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Applications");

        return builder;
    }

    internal static async Task<IResult> ListApplications(
        [FromServices] IApplicationRepository applicationRepository,
        [FromQuery] string? searchTerm,
        [FromQuery] int take = 100,
        [FromQuery] int skip = 0,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            var items = await applicationRepository.GetAsync(take, skip, cancellationToken).ConfigureAwait(false);
            var count = await applicationRepository.GetCountAsync(cancellationToken).ConfigureAwait(false);

            var response = new SinchPageListResponse<ApplicationResponse>(
                ResponseMapper.Map(items),
                count);

            return Results.Ok(response);
        }
        else
        {
            var items = await applicationRepository.SearchAsync(searchTerm, take, skip, cancellationToken).ConfigureAwait(false);
            var count = await applicationRepository.GetCountAsync(searchTerm, cancellationToken).ConfigureAwait(false);

            var response = new SinchPageListResponse<ApplicationResponse>(
                ResponseMapper.Map(items),
                count);

            return Results.Ok(response);
        }
    }

    internal static async Task<IResult> CreateApplication(
        [FromServices] IApplicationRepository applicationRepository,
        [FromBody] ApplicationRequest application,
        CancellationToken cancellationToken = default)
    {
        var model = await applicationRepository
            .AddAsync(application.ToPersistenceModel(), cancellationToken)
            .ConfigureAwait(false);

        return Results.Ok(new SinchResponse<ApplicationResponse>(ResponseMapper.Map(model)));
    }

    internal static async Task<IResult> UpdateApplication(
        [FromServices] IApplicationRepository applicationRepository,
        [FromRoute] Guid applicationId,
        [FromBody] ApplicationRequest application,
        CancellationToken cancellationToken = default)
    {
        var entity = application.ToPersistenceModel();
        entity.Id = applicationId;

        var model = await applicationRepository
            .UpdateAsync(entity, cancellationToken)
            .ConfigureAwait(false);

        return Results.Ok(new SinchResponse<ApplicationResponse>(ResponseMapper.Map(model)));
    }

    internal static async Task<IResult> DeleteApplication(
        [FromServices] IApplicationRepository applicationRepository,
        [FromRoute] Guid applicationId,
        CancellationToken cancellationToken = default)
    {
        await applicationRepository.DeleteAsync(applicationId, cancellationToken).ConfigureAwait(false);

        return Results.NoContent();
    }

}
