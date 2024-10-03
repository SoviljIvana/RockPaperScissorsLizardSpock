using MediatR;
using RPSLS.Application.DTOs;

namespace RPSLS.Application.Play.Commands
{
    public class PlayCommand : IRequest<PlayRepresentation>
    {
        public int Opponent1 { get; set; }
        public int Opponent2 { get; set; }
    }
}
