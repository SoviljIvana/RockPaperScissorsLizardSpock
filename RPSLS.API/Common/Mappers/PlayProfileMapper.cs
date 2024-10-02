using AutoMapper;
using RPSLS.API.Requests.Play;
using RPSLS.Application.Play.Commands;

namespace RPSLS.API.Common.Mappers
{
    public class PlayProfileMapper : Profile
    {
        public PlayProfileMapper()
        {
            CreateMap<PlayRequest, PlayCommand>();
        }
    }
}