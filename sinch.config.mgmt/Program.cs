using Microsoft.OpenApi.Models;
using ServiceRegister;
using Sinch.Config.Mgmt;
using Sinch.Config.Mgmt.Errors;
using Sinch.Config.Mgmt.Persistence;
using System.Text.Json.Nodes;

const string CorsPolicy = nameof(CorsPolicy);

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "Sinch_Config_Mgmt_");

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: CorsPolicy,
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddDbContext<ConfigDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

builder.Services.ConfigureApplicationServices();

builder.Services.AddEndpointsApiExplorer();

var openapiInfo = builder.Configuration.GetSection("OpenApiInfo").Get<OpenApiInfo>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("ConfigMgmt", openapiInfo);
    options.CustomSchemaIds(TypeExtensions.FriendlyTypeName);
    options.MapType<JsonObject>(() => new OpenApiSchema
    {
        Type = "object",
        Nullable = false,
        Title = "JSON"
    });
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(CorsPolicy);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/ConfigMgmt/swagger.json", openapiInfo.Description);
});

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<MockErrorMiddleware>();

app.MapHealthEndpoints();
app.MapApplicationEndpoints();
app.MapEnviromentEndpoints();
app.MapConfigurationEndpoints();

app.Execute();