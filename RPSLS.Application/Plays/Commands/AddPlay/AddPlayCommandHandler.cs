using MediatR;
using RPSLS.Data.Plays;
using RPSLS.Models;

namespace RPSLS.Application.Plays.Commands.AddPlay
{
    public class AddPlayCommandHandler(IPlayerRepository playerRepository) : IRequestHandler<AddPlayCommand, Unit>
    {
        private readonly IPlayerRepository _playerRepository = playerRepository;

        public async Task<Unit> Handle(AddPlayCommand request, CancellationToken cancellationToken)
        {
            var playerToAdd = new Player
            {
                CrationDate = DateTime.UtcNow,
                Id = new Guid(),
                Choice = new Choice
                {
                    Id = request.Player,
                    CrationDate = DateTime.UtcNow
                }

            };

            await _playerRepository.AddPlayer(playerToAdd);

            return Unit.Value;
        }
    }
}