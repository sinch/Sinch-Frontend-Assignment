namespace Sinch.Config.Mgmt.Persistence
{
    public interface IApplicationRepository
    {
        Task<Application?> GetAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Application[]> GetAsync(int take, int skip, CancellationToken cancellationToken = default);

        Task<Application[]> SearchAsync(string searchTerm, int take, int skip, CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(string searchTerm, CancellationToken cancellationToken = default);

        Task<Application> AddAsync(Application application, CancellationToken cancellationToken = default);

        Task<Application> UpdateAsync(Application application, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid applicationId, CancellationToken cancellationToken = default);
    }
}