using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Domain.Entities;
using ServicePlanner.Domain.Services;
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
            _plannerService = plannerService ?? throw new ArgumentNullException(nameof(plannerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpDelete("[action]")]
        public async Task DeleteRecordAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _plannerService.DeleteRecordAsync(id, cancellationToken);
        }

        [HttpGet("[action]")]
        public async Task<RecordResponse> GetRecordByIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var message = await _plannerService.GetRecordByIdAsync(id, cancellationToken);
            return _mapper.Map<RecordResponse>(message);
        }

        [HttpPost("[action]")]
        public async Task<RecordResponse> AddRecordAsync([FromBody] RecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var addedRecord = await _plannerService.CreateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(addedRecord);
        }

        [HttpPost("[action]")]
        public async Task<RecordResponse> UpdateRecordAsync([FromBody] UpdateRecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var updatedRecord = await _plannerService.UpdateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(updatedRecord);
        }

        [HttpPost("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsByDateAsync([FromBody] RecordByDateRequest request, CancellationToken cancellationToken)
        {
            var records = await _plannerService.GetAllRecordByDateAsync
                (request.ProfileId, request.Date, request.Take, request.Offset, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }

        [HttpPost("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsByPeriodAsync([FromBody] RecordByPeriodRequest request, CancellationToken cancellationToken)
        {
            var records = await _plannerService.GetAllRecordsByPeriodAsync
                (request.ProfileId, request.StartDate, request.EndDate, request.Take, request.Offset, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }
    }
}
