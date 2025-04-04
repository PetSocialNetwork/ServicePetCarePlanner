using ServicePetCarePlanner.Domain.Entities;
using ServicePetCarePlanner.Domain.Exceptions;
using ServicePetCarePlanner.Domain.Interfaces;

namespace ServicePetCarePlanner.Domain.Services
{
    public class PetPlannerService
    {
        private readonly IPetPlannerRepository _petPlannerRepository;

        public PetPlannerService
            (IPetPlannerRepository petPlannerRepository)
        {
            _petPlannerRepository = petPlannerRepository
                ?? throw new ArgumentNullException(nameof(petPlannerRepository));
        }

        public async Task<Record> CreateRecordAsync(Record record, CancellationToken cancellationToken)
        { 
            ArgumentNullException.ThrowIfNull(record, nameof(record));
            await _petPlannerRepository.Add(record, cancellationToken);
            return record;
        }

        public async Task<Record> GetRecordByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var record = await _petPlannerRepository.FindRecordAsync(id, cancellationToken);
            if (record == null)
            {
                throw new RecordNotFoundException("Запись не найдена");
            }
            return record;
        }

        public async Task DeleteRecordAsync(Guid id, CancellationToken cancellationToken)
        {
            var record = await _petPlannerRepository.FindRecordAsync(id, cancellationToken);
            if (record == null)
            {
                throw new RecordNotFoundException("Запись не найдена");
            }
            await _petPlannerRepository.Delete(record, cancellationToken);
        }

        public async Task<Record> UpdateRecordAsync(Record record, CancellationToken cancellationToken)
        {
            var existedRecord = await _petPlannerRepository.FindRecordAsync(record.Id, cancellationToken);
            if (existedRecord == null)
            {
                throw new RecordNotFoundException("Запись не найдена");
            }
            existedRecord.Text = record.Text;
            await _petPlannerRepository.Update(existedRecord, cancellationToken);
            return record;
        }

        public async Task<List<Record>> GetAllRecordAsync(CancellationToken cancellationToken)
        {
            return await _petPlannerRepository.GetAll(cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordByDateAsync(DateOnly date, CancellationToken cancellationToken)
        {
            return await _petPlannerRepository.GetAllRecordsByDateAsync(date, cancellationToken);
        }

        public async Task<List<Record>> GetAllRecordsByPeriodAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            return await _petPlannerRepository.GetAllRecordsByPeriodAsync(startDate, endDate, cancellationToken);
        }
       
    }
}
