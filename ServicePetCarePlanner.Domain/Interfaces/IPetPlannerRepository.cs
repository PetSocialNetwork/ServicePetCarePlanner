using ServicePetCarePlanner.Domain.Entities;

namespace ServicePetCarePlanner.Domain.Interfaces
{
    public interface IPetPlannerRepository : IRepositoryEF<Record>
    {
        Task<Record?> FindRecordAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Record>> GetAllRecordsByDateAsync(DateOnly date, CancellationToken cancellationToken);
    }
}
