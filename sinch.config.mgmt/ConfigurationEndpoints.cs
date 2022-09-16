using Microsoft.AspNetCore.Mvc;
using Sinch.Config.Mgmt.Models;
using Sinch.Config.Mgmt.Persistence;
using System.ComponentModel.DataAnnotations;

namespace Sinch.Config.Mgmt;

public static class ConfigurationEndpoints
{
    public static IEndpointRouteBuilder MapConfigurationEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/api/v1/configurations", ListConfigations)
            .Produces<SinchPageListResponse<ConfigurationResponse>>(StatusCodes.Status200OK)
            .WithTags("Configurations");

        builder
            .MapPost("/api/v1/configurations", CreateConfiguration)
            .Produces<SinchResponse<ConfigurationDetailedResponse>>(StatusCodes.Status200OK)
            .WithTags("Configurations");

        builder
            .MapGet("/api/v1/configurations/{configurationId}", GetConfiguration)
            .Produces<SinchResponse<ConfigurationDetailedResponse>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Configurations");

        builder
            .MapPost("/api/v1/configurations/{configurationId}/active", SetActiveConfiguration)
            .Produces<SinchResponse<ConfigurationResponse>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Configurations");

        return builder;
    }

    internal static async Task<IResult> ListConfigations(
       [FromServices] IConfigurationRepository configationRepository,
       [FromQuery, Required] Guid applicationId,
       [FromQuery, Required] Guid enviromentId,
       [FromQuery] int take = 100,
       [FromQuery] int skip = 0,
       CancellationToken cancellationToken = default)
    {
        var items = await configationRepository.GetAsync(enviromentId, take, skip, cancellationToken).ConfigureAwait(false);
        var count = await configationRepository.GetCountAsync(enviromentId, cancellationToken).ConfigureAwait(false);

        var response = new SinchPageListResponse<ConfigurationResponse>(
            ResponseMapper.Map(items),
            count);

        return Results.Ok(response);
    }

    internal static async Task<IResult> GetConfiguration(
        [FromServices] IConfigurationRepository configationRepository,
        [FromRoute] Guid configurationId,
        CancellationToken cancellationToken = default)
    {
        var item = await configationRepository.GetAsync(configurationId, cancellationToken).ConfigureAwait(false);

        if (item is not null)
        {
            return Results.Ok(new SinchResponse<ConfigurationDetailedResponse>(ResponseMapper.MapDetails(item)));
        }

        return Results.NotFound(new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = $"Configuration with ID {configurationId} not found"
        });
    }

    internal static async Task<IResult> CreateConfiguration(
        [FromServices] IConfigurationRepository configationRepository,
        [FromBody] ConfigurationRequest configuration,
        CancellationToken cancellationToken = default)
    {
        var entity = configuration.ToPersistenceModel();

        entity = await configationRepository.AddAsync(entity, cancellationToken).ConfigureAwait(false);

        return Results.Ok(new SinchResponse<ConfigurationDetailedResponse>(ResponseMapper.MapDetails(entity)));
    }

    internal static async Task<IResult> SetActiveConfiguration(
        [FromServices] IConfigurationRepository configationRepository,
        [FromRoute] Guid configurationId,
        CancellationToken cancellationToken = default)
    {
        var configuration = await configationRepository.SetActiveAsync(configurationId, cancellationToken).ConfigureAwait(false);

        return Results.Ok(new SinchResponse<ConfigurationResponse>(ResponseMapper.Map(configuration)));
    }
}
