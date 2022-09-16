using Sinch.Config.Mgmt.Persistence;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Sinch.Config.Mgmt;

public static class WebApplicationExtensions
{
    public static void Execute(this WebApplication webApplication)
    {
        var logger = webApplication.Services.GetRequiredService<ILogger<Program>>();
        var errorRate = webApplication.Configuration.GetSection("MockErrorRate").Value;

        logger.LogInformation("Runtime : {FrameworkDescription} {ProcessArchitecture}", RuntimeInformation.FrameworkDescription, RuntimeInformation.ProcessArchitecture);
        logger.LogInformation("Platform : {OSDescription} {OSArchitecture}", RuntimeInformation.OSDescription, RuntimeInformation.OSArchitecture);
        logger.LogInformation("Server GC : {IsServerGC}", GCSettings.IsServerGC);
        logger.LogInformation("Mock Error Rate : {errorRate}", errorRate);

        MigrateDatabase(webApplication);

        webApplication.Run();
    }

    private static void MigrateDatabase(WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ConfigDbContext>();
        context.Database.Migrate();
    }
}
