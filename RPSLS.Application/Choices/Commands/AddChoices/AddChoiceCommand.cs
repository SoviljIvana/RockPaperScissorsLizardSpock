using MediatR;

namespace RPSLS.Application.Choices.Commands.AddChoices
{
    public class AddChoiceCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
