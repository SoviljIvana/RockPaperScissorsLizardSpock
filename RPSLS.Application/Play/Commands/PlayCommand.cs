using MediatR;
using RPSLS.Application.DTOs;

namespace RPSLS.Application.Play.Commands
{
    public class PlayCommand : IRequest<PlayRepresentation>
    {
        public int Player { get; set; }
    }
}
