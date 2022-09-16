using ServiceRegister;

namespace Sinch.Config.Mgmt.Errors;

[SingletonService(implementationAsSelf: true)]
public class MockErrorMiddleware : IMiddleware
{
    public MockErrorMiddleware(IConfiguration configuration)
    {
        _ = float.TryParse(configuration.GetSection("MockErrorRate").Value, out float errorRate);
        ErrorRate = errorRate;
    }

    private float ErrorRate { get; init; }

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var shouldErrorOut = Random.Shared.NextSingle() < ErrorRate;

        if (shouldErrorOut)
        {
            throw new MockException("There was an error performing the request");
        }
        
        return next(context);
    }
}
