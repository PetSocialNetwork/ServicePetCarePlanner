﻿using ServicePlanner.Domain.Entities;

namespace ServicePlanner.Domain.Interfaces
{
    public interface IPlannerRepository : IRepositoryEF<Record>
    {
        Task<Record?> FindRecordAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Record>> GetAllRecordsByDateAsync
            (Guid profileId, DateOnly date, int take, int offset, CancellationToken cancellationToken);
        Task<List<Record>> GetAllRecordsByPeriodAsync
            (Guid profileId, DateOnly startDate, DateOnly endDate, int take, int offset, CancellationToken cancellationToken);
    }
}
