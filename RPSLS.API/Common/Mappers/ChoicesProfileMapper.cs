using AutoMapper;
using RPSLS.API.Requests.Choices;
using RPSLS.Application.Choices.Commands.AddChoices;

namespace RPSLS.API.Common.Mappers
{
    public class ChoicesProfileMapper : Profile
    {
        public ChoicesProfileMapper()
        {
            CreateMap<AddChoicesRequest, AddChoicesCommand>()
               .ForPath(d => d.Choices, opt => opt.MapFrom(s => s.Choices));

            CreateMap<AddChoiceRequest, AddChoiceCommand>()
               .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
               .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));

        }
    }
}