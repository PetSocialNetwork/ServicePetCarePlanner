using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePetCarePlanner.Domain.Entities;
using ServicePetCarePlanner.Domain.Services;
using ServicePetCarePlanner.WebApi.Models.Requests;
using ServicePetCarePlanner.WebApi.Models.Responses;

namespace ServicePetCarePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetPlannerController : ControllerBase
    {
        private readonly PetPlannerService _petPlannerService;
        private readonly IMapper _mapper;

        public PetPlannerController(PetPlannerService petPlannerService,
            IMapper mapper)
        {
            _petPlannerService = petPlannerService ?? throw new ArgumentNullException(nameof(petPlannerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RecordNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[action]")]
        public async Task DeleteRecordAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _petPlannerService.DeleteRecordAsync(id, cancellationToken);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RecordNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]")]
        public async Task<RecordResponse> GetRecordByIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var message = await _petPlannerService.GetRecordByIdAsync(id, cancellationToken);
            return _mapper.Map<RecordResponse>(message);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("[action]")]
        public async Task<RecordResponse> AddRecordAsync([FromBody] RecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var addedRecord = await _petPlannerService.CreateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(addedRecord);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("[action]")]
        public async Task<RecordResponse> UpdateRecordAsync([FromBody] UpdateRecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var updatedRecord = await _petPlannerService.UpdateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(updatedRecord);
        }
       
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsAsync(CancellationToken cancellationToken)
        {
            var records = await _petPlannerService.GetAllRecordAsync (cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsByDateAsync([FromBody] RecordByDateRequest request, CancellationToken cancellationToken)
        {
            var records = await _petPlannerService.GetAllRecordByDateAsync(request.Date, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }
    }
}
