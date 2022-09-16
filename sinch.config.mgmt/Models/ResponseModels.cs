using Sinch.Config.Mgmt.Persistence;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Sinch.Config.Mgmt.Models;

public record SinchResponse<T>(T Data);

public record SinchPageListResponse<T> (IEnumerable<T> Data, int TotalCount) : SinchResponse<IEnumerable<T>>(Data);

public record ApplicationResponse(Guid Id, string Name, string Description);

public record EnviromentResponse(Guid Id, Guid ApplicationId, string Name, string Region);

public record ConfigurationResponse(Guid Id, Guid EnviromentId, bool Active);

public record ConfigurationDetailedResponse(Guid Id, Guid EnviromentId, bool Active, JsonObject? Data);

internal static class ResponseMapper
{
    public static ApplicationResponse Map(Application application) => new (application.Id, application.Name, application.Description);

    public static IEnumerable<ApplicationResponse> Map(IEnumerable<Application> items) => items.Select(Map).ToArray();

    public static EnviromentResponse Map(Persistence.Environment enviroment) => new(enviroment.Id, enviroment.ApplicationId, enviroment.Name, enviroment.Region);

    public static IEnumerable<EnviromentResponse> Map(IEnumerable<Persistence.Environment> items) => items.Select(Map).ToArray();

    public static ConfigurationResponse Map(Configuration configation) => new(configation.Id, configation.EnviromentId, configation.Active);

    public static IEnumerable<ConfigurationResponse> Map(IEnumerable<Configuration> items) => items.Select(Map).ToArray();

    public static ConfigurationDetailedResponse MapDetails(Configuration configation) => new(configation.Id, configation.EnviromentId, configation.Active, JsonSerializer.Deserialize<JsonObject>(configation.Data));
}