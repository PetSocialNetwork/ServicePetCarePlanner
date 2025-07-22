using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Services;
using ServicePlanner.Domain.Shared;
using ServicePlanner.WebApi.Models.Requests;
using ServicePlanner.WebApi.Models.Responses;

namespace ServicePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlannerController : ControllerBase
    {
        private readonly PlannerService _plannerService;
        private readonly IMapper _mapper;

        public PlannerController(PlannerService plannerService,
            IMapper mapper)
        {
            _plannerService = plannerService 
                ?? throw new ArgumentNullException(nameof(plannerService));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Удаляет запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpDelete("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task DeleteRecordAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _plannerService.DeleteRecordAsync(id, cancellationToken);
        }

        /// <summary>
        /// Возвращает запись по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<RecordResponse> GetRecordByIdAsync
            ([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var message = await _plannerService.GetRecordByIdAsync(id, cancellationToken);
            return _mapper.Map<RecordResponse>(message);
        }

        /// <summary>
        /// Добавляет запись
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<RecordResponse> AddRecordAsync
            ([FromBody] RecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var addedRecord = await _plannerService.CreateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(addedRecord);
        }

        /// <summary>
        /// Обновляет запись
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<RecordResponse> UpdateRecordAsync
            ([FromBody] UpdateRecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var updatedRecord = await _plannerService.UpdateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(updatedRecord);
        }

        /// <summary>
        /// Возвращает все запись за один день
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<RecordResponse>> GetAllRecordsByDateAsync
            ([FromBody] RecordByDateRequest request, CancellationToken cancellationToken)
        {
            var options = _mapper.Map<PaginationOptions>(request);
            var records = await _plannerService.GetAllRecordByDateAsync
                (request.ProfileId, request.Date, options, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }
        
        /// <summary>
        /// Возвращает все записи за период
        /// </summary>
        /// <param name="request">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<List<RecordResponse>> GetAllRecordsByPeriodAsync
            ([FromBody] RecordByPeriodRequest request, CancellationToken cancellationToken)
        {
            var options = _mapper.Map<PaginationOptions>(request);
            var records = await _plannerService.GetAllRecordsByPeriodAsync
                (request.ProfileId, request.StartDate, request.EndDate, options, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }
    }
}
