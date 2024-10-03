using AutoMapper;
using RPSLS.Application.DTOs;

namespace RPSLS.Application.Play.Common
{
    public class PlayRepresentationProfileMapper : Profile
    {
        public PlayRepresentationProfileMapper()
        {
            CreateMap<Models.Play, PlayRepresentation>()
                .ForMember(dest => dest.Player, act => act.MapFrom(src => src.Opponent1))
                .ForMember(dest => dest.Computer, act => act.MapFrom(src => src.Opponent2))
                .ForMember(dest => dest.Results, act => act.MapFrom(src => src.Results));
        }
    }
}
