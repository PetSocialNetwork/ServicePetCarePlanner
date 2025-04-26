using AutoMapper;
using ServicePlanner.Domain.Entities;
using ServicePlanner.WebApi.Models.Requests;
using ServicePlanner.WebApi.Models.Responses;

namespace ServicePlanner.WebApi.Mappings
{
    public class PlannerProfile : Profile
    {
        public PlannerProfile()
        {
            CreateMap<UpdateRecordRequest, Record>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.ProfileId, opt => opt.Ignore())
                .ForMember(dest => dest.Date, opt => opt.Ignore());

            CreateMap<RecordRequest, Record>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ProfileId, opt => opt.MapFrom(src => src.ProfileId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

            CreateMap<Record, RecordResponse>();
        }
    }
}
