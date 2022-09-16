using Sinch.Config.Mgmt.Persistence;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Sinch.Config.Mgmt.Models;

public record ApplicationRequest(string Name, string Description)
{
    public Application ToPersistenceModel() => new()
    {
        Name = Name,
        Description = Description,
    };
};

public record EnviromentRequest([property: JsonIgnore]Guid ApplicationId, string Name, string Region)
{
    public Persistence.Environment ToPersistenceModel(Guid? id = null) => new()
    {
        Id = id ?? Guid.NewGuid(),
        ApplicationId = ApplicationId,
        Name = Name,
        Region = Region,
    };
}

public record ConfigurationRequest(Guid ApplicationId, Guid EnviromentId, JsonObject Data)
{
    public Configuration ToPersistenceModel(bool active = false) => new()
    {
        EnviromentId = EnviromentId,
        Data = Data.ToJsonString(),
        Active = active,
    };
}