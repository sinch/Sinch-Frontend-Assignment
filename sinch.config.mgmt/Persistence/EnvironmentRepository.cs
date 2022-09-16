using ServiceRegister;
using Sinch.Config.Mgmt.Errors;

namespace Sinch.Config.Mgmt.Persistence;

[ScopedService]
public class EnvironmentRepository : IEnvironmentRepository
{
    private readonly ConfigDbContext _dbContext;

    public EnvironmentRepository(ConfigDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> GetCountAsync(Guid applicationId, CancellationToken cancellationToken = default)
        => _dbContext.Environments
            .Where(e => e.ApplicationId == applicationId)
            .CountAsync(cancellationToken);

    public Task<int> GetCountAsync(Guid applicationId, string searchTerm, CancellationToken cancellationToken = default)
        => _dbContext.Environments
            .Where(a => a.ApplicationId == applicationId && a.Name.ToLower().Contains(searchTerm.ToLower()))
            .CountAsync(cancellationToken);

    public Task<Environment?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => _dbContext.Environments
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    public Task<Environment[]> GetAsync(Guid applicationId, int take, int skip, CancellationToken cancellationToken = default)
        => _dbContext.Environments
            .Where(e => e.ApplicationId == applicationId)
            .OrderBy(a => a.Id)
            .Skip(skip)
            .Take(take)
            .ToArrayAsync(cancellationToken);

    public Task<Environment[]> SearchAsync(Guid applicationId, string searchTerm, int take, int skip, CancellationToken cancellationToken = default)
        => _dbContext.Environments
            .Where(a => a.ApplicationId == applicationId && a.Name.ToLower().Contains(searchTerm.ToLower()))
            .OrderBy(a => a.Id)
            .Skip(skip)
            .Take(take)
            .ToArrayAsync(cancellationToken);

    public async Task<Environment> AddAsync(Environment enviroment, CancellationToken cancellationToken = default)
    {
        _dbContext.Environments.Add(enviroment);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return enviroment;
    }

    public async Task<Environment> UpdateAsync(Environment enviroment, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Environments.FirstOrDefaultAsync(a => a.Id == enviroment.Id, cancellationToken).ConfigureAwait(false);

        if (entity is null)
        {
            throw new DocumentNotFoundException($"Update error: Environment with ID {enviroment.Id} not found");
        }

        _dbContext.Environments.Update(enviroment);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return enviroment;
    }

    public async Task DeleteAsync(Guid enviromentId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Environments.FirstOrDefaultAsync(a => a.Id == enviromentId, cancellationToken).ConfigureAwait(false);

        if (entity is null)
        {
            throw new DocumentNotFoundException($"Delete error: Environment with ID {enviromentId} not found");
        }

        _dbContext.Environments.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
