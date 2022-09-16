namespace Sinch.Config.Mgmt.Persistence
{
    public interface IConfigurationRepository
    {
        Task<Configuration> AddAsync(Configuration configation, CancellationToken cancellationToken = default);
        Task<Configuration?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Configuration[]> GetAsync(Guid enviromentId, int take, int skip, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Guid enviromentId, CancellationToken cancellationToken = default);
        Task<Configuration> SetActiveAsync(Guid id, CancellationToken cancellationToken = default);
    }
}