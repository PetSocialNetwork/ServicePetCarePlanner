using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Shared;

namespace ServicePlanner.Domain.Interfaces
{
    public interface IPlannerRepository : IRepositoryEF<Record>
    {
        Task<Record?> FindRecordAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Record>> GetAllRecordsByDateAsync
            (Guid profileId, DateOnly date, PaginationOptions options, CancellationToken cancellationToken);
        Task<List<Record>> GetAllRecordsByPeriodAsync
            (Guid profileId, DateOnly startDate, DateOnly endDate, PaginationOptions options, CancellationToken cancellationToken);
    }
}
