using Microsoft.EntityFrameworkCore;
using ServicePetCarePlanner.Domain.Entities;
using ServicePetCarePlanner.Domain.Interfaces;


namespace ServicePetCarePlanner.DataEntityFramework.Repositories
{
    public class PetPlannerRepository : EFRepository<Record>, IPetPlannerRepository
    {
        public PetPlannerRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Record?> FindRecordAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordsByDateAsync(DateOnly date, CancellationToken cancellationToken)
        {
            return await Entities.Where(it => it.Date == date).ToListAsync(cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordsByPeriodAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            return await Entities
                    .Where(it => it.Date >= startDate && it.Date <= endDate)
                    .ToListAsync(cancellationToken);
        }     
    }
}
