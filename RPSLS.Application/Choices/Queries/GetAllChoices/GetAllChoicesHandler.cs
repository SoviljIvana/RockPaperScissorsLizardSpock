using AutoMapper;
using MediatR;
using RPSLS.Application.DTOs;
using RPSLS.Data.Choices;

namespace RPSLS.Application.Choices.Queries.GetAllChoices
{
    public class GetAllChoicesHandler(IChoiceRepository choiceRepository, IMapper mapper) : IRequestHandler<GetAllChoicesQuery, List<ChoiceRepresentation>>
    {
        private readonly IChoiceRepository _choiceRepository = choiceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ChoiceRepresentation>> Handle(GetAllChoicesQuery request, CancellationToken cancellationToken)
        {
            var choices = await _choiceRepository.GetAllChoices();

            var result = _mapper.Map<List<Models.Choice>, List<ChoiceRepresentation>>(choices!);

            return result;
        }
    }
}