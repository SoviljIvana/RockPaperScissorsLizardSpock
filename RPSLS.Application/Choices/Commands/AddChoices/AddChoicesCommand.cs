using MediatR;

namespace RPSLS.Application.Choices.Commands.AddChoices
{
    public class AddChoicesCommand : IRequest<Unit>
    {
        public List<AddChoiceCommand>? Choices { get; set; }
    }
}
