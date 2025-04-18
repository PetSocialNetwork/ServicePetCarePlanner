﻿using AutoMapper;
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

        [HttpDelete("[action]")]
        public async Task DeleteRecordAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            await _petPlannerService.DeleteRecordAsync(id, cancellationToken);
        }

        [HttpGet("[action]")]
        public async Task<RecordResponse> GetRecordByIdAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var message = await _petPlannerService.GetRecordByIdAsync(id, cancellationToken);
            return _mapper.Map<RecordResponse>(message);
        }

        [HttpPost("[action]")]
        public async Task<RecordResponse> AddRecordAsync([FromBody] RecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var addedRecord = await _petPlannerService.CreateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(addedRecord);
        }

        [HttpPost("[action]")]
        public async Task<RecordResponse> UpdateRecordAsync([FromBody] UpdateRecordRequest request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);
            var updatedRecord = await _petPlannerService.UpdateRecordAsync(record, cancellationToken);
            return _mapper.Map<RecordResponse>(updatedRecord);
        }

        [HttpGet("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsAsync(CancellationToken cancellationToken)
        {
            var records = await _petPlannerService.GetAllRecordAsync (cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }

        [HttpPost("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsByDateAsync([FromBody] RecordByDateRequest request, CancellationToken cancellationToken)
        {
            var records = await _petPlannerService.GetAllRecordByDateAsync(request.Date, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }

        [HttpPost("[action]")]
        public async Task<List<RecordResponse>> GetAllRecordsByPeriodAsync([FromBody] RecordByPeriodRequest request, CancellationToken cancellationToken)
        {
            var records = await _petPlannerService.GetAllRecordsByPeriodAsync(request.StartDate, request.EndDate, cancellationToken);
            return _mapper.Map<List<RecordResponse>>(records);
        }
    }
}
