﻿using Microsoft.EntityFrameworkCore;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Interfaces;


namespace ServicePlanner.DataEntityFramework.Repositories
{
    public class PlannerRepository : EFRepository<Record>, IPlannerRepository
    {
        public PlannerRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Record?> FindRecordAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordsByDateAsync
            (Guid profileId, 
            DateOnly date, 
            int take, 
            int offset, 
            CancellationToken cancellationToken)
        {
            return await Entities
                .Where(it => it.Date == date && it.ProfileId == profileId)
                .Skip(offset * take)
                .Take(take)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordsByPeriodAsync
            (Guid profileId, 
            DateOnly startDate, 
            DateOnly endDate,
            int take,
            int offset,
            CancellationToken cancellationToken)
        {
            return await Entities
                    .Where(it => it.Date >= startDate && it.Date <= endDate && it.ProfileId == profileId)
                    .Skip(offset * take)
                    .Take(take)
                    .ToListAsync(cancellationToken);
        }     
    }
}
