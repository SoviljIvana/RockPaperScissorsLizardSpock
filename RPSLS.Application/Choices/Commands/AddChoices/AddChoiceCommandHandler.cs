using MediatR;
using RPSLS.Data.Choices;
using RPSLS.Models;

namespace RPSLS.Application.Choices.Commands.AddChoices
{
    public class AddChoiceCommandHandler(IChoiceRepository choiceRepository) : IRequestHandler<AddChoiceCommand, Unit>
    {
        private readonly IChoiceRepository _choiceRepository = choiceRepository;

        public async Task<Unit> Handle(AddChoiceCommand request, CancellationToken cancellationToken)
        {
                await _choiceRepository.AddChoice(new Choice
                {
                    Id = request.Id,
                    Name = request.Name,
                    CrationDate = DateTime.UtcNow
                });

            return Unit.Value;
        }
    }
}