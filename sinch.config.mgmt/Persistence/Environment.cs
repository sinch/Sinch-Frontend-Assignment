using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinch.Config.Mgmt.Persistence;

public record Environment
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey(nameof(Application)), Required]
    public Guid ApplicationId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public Application? Application { get; set; }
}
