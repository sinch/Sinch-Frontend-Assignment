using ServiceRegister;
using Sinch.Config.Mgmt.Errors;

namespace Sinch.Config.Mgmt.Persistence;

[ScopedService]
public class ApplicationRepository : IApplicationRepository
{
    private readonly ConfigDbContext _dbContext;

    public ApplicationRepository(ConfigDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        => _dbContext.Applications
            .CountAsync(cancellationToken);

    public Task<int> GetCountAsync(string searchTerm, CancellationToken cancellationToken = default)
        => _dbContext.Applications
            .Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()))
            .CountAsync(cancellationToken);

    public Task<Application?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => _dbContext.Applications
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    public Task<Application[]> GetAsync(int take, int skip, CancellationToken cancellationToken = default)
        => _dbContext.Applications
            .OrderBy(a => a.Id)
            .Skip(skip)
            .Take(take)
            .ToArrayAsync(cancellationToken);

    public Task<Application[]> SearchAsync(string searchTerm, int take, int skip, CancellationToken cancellationToken = default)
        => _dbContext.Applications
            .Where(a => a.Name.ToLower().Contains(searchTerm.ToLower())).OrderBy(a => a.Id)
            .Skip(skip)
            .Take(take)
            .ToArrayAsync(cancellationToken);

    public async Task<Application> AddAsync(Application application, CancellationToken cancellationToken = default)
    {
        _dbContext.Applications.Add(application);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return application;
    }

    public async Task<Application> UpdateAsync(Application application, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Applications.FirstOrDefaultAsync(a => a.Id == application.Id, cancellationToken).ConfigureAwait(false);

        if (entity is null)
        {
            throw new DocumentNotFoundException($"Update error: Application with ID {application.Id} not found");
        }

        _dbContext.Applications.Update(application);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return application;
    }

    public async Task DeleteAsync(Guid applicationId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Applications.FirstOrDefaultAsync(a => a.Id == applicationId, cancellationToken).ConfigureAwait(false);

        if (entity is null)
        {
            throw new DocumentNotFoundException($"Delete error: Application with ID {applicationId} not found");
        }

        _dbContext.Applications.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
