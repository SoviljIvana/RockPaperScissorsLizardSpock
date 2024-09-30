using MediatR;
using RPSLS.Application.DTOs;

namespace RPSLS.Application.Choices.Queries.GetRandomChoice
{
    public class GetRandomChoiceQuery : IRequest<ChoiceRepresentation>
    {
    }
}
