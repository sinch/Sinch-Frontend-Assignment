using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinch.Config.Mgmt.Persistence;

public class Configuration
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey(nameof(Enviroment)), Required]
    public Guid EnviromentId { get; set; }

    public bool Active { get; set; } = true;

    [Column(TypeName = "JSON")]
    public string Data { get; set; } = "{}";

    public Environment? Enviroment { get; set; }
}