using AutoMapper;
using RPSLS.API.Requests.Plays;
using RPSLS.Application.Plays.Commands.AddPlay;

namespace RPSLS.API.Common.Mappers
{
    public class PlaysProfileMapper : Profile
    {
        public PlaysProfileMapper()
        {
            CreateMap<AddPlayRequest, AddPlayCommand>();
        }
    }
}