namespace Sinch.Config.Mgmt.Persistence
{
    public interface IEnvironmentRepository
    {
        Task<Environment> AddAsync(Environment enviroment, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid enviromentId, CancellationToken cancellationToken = default);
        Task<Environment?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Environment[]> GetAsync(Guid applicationId, int take, int skip, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Guid applicationId, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Guid applicationId, string searchTerm, CancellationToken cancellationToken = default);
        Task<Environment[]> SearchAsync(Guid applicationId, string searchTerm, int take, int skip, CancellationToken cancellationToken = default);
        Task<Environment> UpdateAsync(Environment enviroment, CancellationToken cancellationToken = default);
    }
}