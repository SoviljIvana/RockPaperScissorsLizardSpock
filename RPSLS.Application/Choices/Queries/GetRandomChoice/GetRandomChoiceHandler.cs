using AutoMapper;
using MediatR;
using RPSLS.Application.DTOs;
using RPSLS.Data.Choices;

namespace RPSLS.Application.Choices.Queries.GetRandomChoice
{
    public class GetRandomChoiceHandler(IChoiceRepository choiceRepository, IMapper mapper) : IRequestHandler<GetRandomChoiceQuery, ChoiceRepresentation>
    {
        private readonly IChoiceRepository _choiceRepository = choiceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ChoiceRepresentation> Handle(GetRandomChoiceQuery request, CancellationToken cancellationToken)
        {
            var randomNumber = GetRandomNumber();

            var choice = await _choiceRepository.GetChoiceById(randomNumber);

            var result = _mapper.Map<Models.Choice, ChoiceRepresentation>(choice!);

            return result;
        }

        private static int GetRandomNumber()
        {
            Random random = new();

            return random.Next(1, 5);
        }
    }
}