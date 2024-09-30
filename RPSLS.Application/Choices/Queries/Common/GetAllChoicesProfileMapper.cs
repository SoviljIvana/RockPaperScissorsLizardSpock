using AutoMapper;
using RPSLS.Application.DTOs;

namespace RPSLS.Application.Choices.Queries.Common
{
    public class GetAllChoicesProfileMapper : Profile
    {
        public GetAllChoicesProfileMapper()
        {
            CreateMap<Models.Choice, ChoiceRepresentation>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id));
        }
    }
}
