using MediatR;
using RPSLS.Application.DTOs;

namespace RPSLS.Application.Choices.Queries.GetAllChoices
{
    public class GetAllChoicesQuery : IRequest<List<ChoiceRepresentation>>
    {
    }
}
