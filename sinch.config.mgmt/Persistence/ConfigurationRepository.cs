using ServiceRegister;
using Sinch.Config.Mgmt.Errors;

namespace Sinch.Config.Mgmt.Persistence;

[ScopedService]
public class ConfigurationRepository : IConfigurationRepository
{
    private readonly ConfigDbContext _dbContext;

    public ConfigurationRepository(ConfigDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> GetCountAsync(Guid enviromentId, CancellationToken cancellationToken = default)
        => _dbContext.Configurations.Where(e => e.EnviromentId == enviromentId).CountAsync(cancellationToken);

    public Task<Configuration?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => _dbContext.Configurations.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    public Task<Configuration[]> GetAsync(Guid enviromentId, int take, int skip, CancellationToken cancellationToken = default)
        => _dbContext.Configurations.Where(e => e.EnviromentId == enviromentId).OrderBy(a => a.Id).Skip(skip).Take(take).ToArrayAsync(cancellationToken);

    public async Task<Configuration> AddAsync(Configuration configation, CancellationToken cancellationToken = default)
    {
        _dbContext.Configurations.Add(configation);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return configation;
    }

    public async Task<Configuration> SetActiveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var configuration = await GetAsync(id, cancellationToken).ConfigureAwait(false);

        if (configuration is null)
        {
            throw new DocumentNotFoundException($"Set active error: Configuration with ID {id} not found");
        }

        configuration.Active = true;

        using var transaction = _dbContext.Database.BeginTransaction();

        try
        {
            await _dbContext.Database
                .ExecuteSqlInterpolatedAsync(
                    $"UPDATE Configurations SET Active = False WHERE EnviromentId = {configuration.EnviromentId} AND Id <> {configuration.Id}",
                    cancellationToken)
                .ConfigureAwait(false);

            _dbContext.Configurations.Update(configuration);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            await transaction.CommitAsync(cancellationToken).ConfigureAwait(!false);

        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken).ConfigureAwait(!false);
            throw;
        }

        return configuration;
    }
}