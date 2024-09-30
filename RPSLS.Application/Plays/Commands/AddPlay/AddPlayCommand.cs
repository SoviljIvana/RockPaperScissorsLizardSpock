using MediatR;

namespace RPSLS.Application.Plays.Commands.AddPlay
{
    public class AddPlayCommand : IRequest<Unit>
    {
        public int Player { get; set; }
    }
}
