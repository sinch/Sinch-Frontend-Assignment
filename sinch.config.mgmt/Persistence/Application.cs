﻿namespace Sinch.Config.Mgmt.Persistence;

public class Application
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
