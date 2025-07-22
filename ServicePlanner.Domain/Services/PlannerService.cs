using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Exceptions;
using ServicePlanner.Domain.Interfaces;
using ServicePlanner.Domain.Shared;

namespace ServicePlanner.Domain.Services
{
    public class PlannerService
    {
        private readonly IPlannerRepository _plannerRepository;

        public PlannerService
            (IPlannerRepository plannerRepository)
        {
            _plannerRepository = plannerRepository
                ?? throw new ArgumentNullException(nameof(plannerRepository));
        }

        public async Task<Record> CreateRecordAsync
            (Record record, CancellationToken cancellationToken)
        { 
            await _plannerRepository.Add(record, cancellationToken);
            return record;
        }

        public async Task<Record> GetRecordByIdAsync
            (Guid id, CancellationToken cancellationToken)
        {
            var record = await _plannerRepository.FindRecordAsync(id, cancellationToken)
                ?? throw new RecordNotFoundException("Запись не найдена");
            return record;
        }

        public async Task DeleteRecordAsync
            (Guid id, CancellationToken cancellationToken)
        {
            var record = await _plannerRepository.FindRecordAsync(id, cancellationToken)
                ?? throw new RecordNotFoundException("Запись не найдена");
            await _plannerRepository.Delete(record, cancellationToken);
        }

        public async Task<Record> UpdateRecordAsync
            (Record record, CancellationToken cancellationToken)
        {
            var existedRecord = await _plannerRepository.FindRecordAsync(record.Id, cancellationToken)
                ?? throw new RecordNotFoundException("Запись не найдена");

            existedRecord.Text = record.Text;
            await _plannerRepository.Update(existedRecord, cancellationToken);
            return record;
        }

        public async Task<List<Record>> GetAllRecordAsync(CancellationToken cancellationToken)
        {
            return await _plannerRepository.GetAll(cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordByDateAsync
            (Guid profileId, 
            DateOnly date,
            PaginationOptions options,
            CancellationToken cancellationToken)
        {
            return await _plannerRepository.GetAllRecordsByDateAsync
                (profileId, date, options, cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordsByPeriodAsync
            (Guid profileId, 
            DateOnly startDate, 
            DateOnly endDate,
            PaginationOptions options,
            CancellationToken cancellationToken)
        {
            return await _plannerRepository.GetAllRecordsByPeriodAsync
                (profileId, startDate, endDate, options, cancellationToken);
        }      
    }
}
