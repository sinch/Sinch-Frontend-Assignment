using System.Text.Json;

namespace Sinch.Config.Mgmt.Persistence;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        var applications = new Application[]
        {
            new Application
            {
                Name = "RTC.ApiGateway",
                Description = "RTC API Gateway"
            },
            new Application
            {
                Name = "RTC.CallingApi",
                Description = "RTC Calling API"
            },
            new Application
            {
                Name = "RTC.CallingApplication",
                Description = "RTC Calling Application"
            },
            new Application
            {
                Name = "RTC.CallingService",
                Description = "RTC Calling Service"
            },
            new Application
            {
                Name = "RTC.BillingApplication",
                Description = "RTC Billing Application"
            },
            new Application
            {
                Name = "RTC.BillingService",
                Description = "RTC Billing Service"
            }
        };

        var enviroments = applications.SelectMany(
            a => new[] { "Dev", "Qa", "Prod" }.Select(
                e => new Environment
                {
                    ApplicationId = a.Id,
                    Name = e,
                    Region = "EU-West1"
                })).ToArray();

        var configations = enviroments.Select(e => new Configuration
        {
            EnviromentId = e.Id,
            Active = true,
            Data = JsonSerializer.Serialize(new
            {
                AllowedHosts = "*",
                ConnectionStrings = new Dictionary<string, string>
                {
                    ["Sqlite"] = "Data Source=.\\app.db",
                },
                Logging = new
                {
                    LogLevel = new Dictionary<string, string>
                    {
                        ["Default"] = Enum.GetName(LogLevel.Warning)!,
                        ["Microsoft.AspNetCore"] = Enum.GetName(LogLevel.Warning)!,
                        ["Sinch"] = Enum.GetName(LogLevel.Information)!,
                    }
                },
                MyKey = "MyValue123",
                ServerKey = "FooBaz123",
            })
        }).ToArray();

        builder.Entity<Application>().HasData(applications);
        builder.Entity<Environment>().HasData(enviroments);
        builder.Entity<Configuration>().HasData(configations);
    }
}
