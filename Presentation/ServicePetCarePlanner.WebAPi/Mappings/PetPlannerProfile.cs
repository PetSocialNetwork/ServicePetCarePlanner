using AutoMapper;
using ServicePetCarePlanner.Domain.Entities;
using ServicePetCarePlanner.WebApi.Models.Requests;
using ServicePetCarePlanner.WebApi.Models.Responses;

namespace ServicePetCarePlanner.WebApi.Mappings
{
    public class PetPlannerProfile : Profile
    {
        public PetPlannerProfile()
        {
            CreateMap<UpdateRecordRequest, Record>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.Date, opt => opt.Ignore());

            CreateMap<RecordRequest, Record>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

            CreateMap<Record, RecordResponse>();
        }
    }
}
