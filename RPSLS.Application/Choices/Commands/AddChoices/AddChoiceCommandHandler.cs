using MediatR;
using RPSLS.Data.Choices;
using RPSLS.Models;

namespace RPSLS.Application.Choices.Commands.AddChoices
{
    public class AddChoiceCommandHandler(IChoiceRepository choiceRepository) : IRequestHandler<AddChoicesCommand, Unit>
    {
        private readonly IChoiceRepository _choiceRepository = choiceRepository;

        public async Task<Unit> Handle(AddChoicesCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Choices!)
            {
                await _choiceRepository.AddChoice(new Choice
                {
                    CrationDate = DateTime.UtcNow,
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return Unit.Value;
        }
    }
}