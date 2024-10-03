using AutoMapper;
using MediatR;
using RPSLS.Application.DTOs;
using RPSLS.Application.WinnerCalculations;
using RPSLS.Data.Plays;
using RPSLS.Infrastructure.Clients.CodeChallenge;

namespace RPSLS.Application.Play.Commands
{
    public class PlayCommandHandler(IPlayRepository playRepository,
        ICodeChallengeApiClient apiClient, IMapper mapper,
        IWinnerCalculation winnerCalculation) : IRequestHandler<PlayCommand, PlayRepresentation>
    {
        private readonly IPlayRepository _playRepository = playRepository;
        private readonly ICodeChallengeApiClient _apiClient = apiClient;
        private readonly IWinnerCalculation _winnerCalculation = winnerCalculation;
        private readonly IMapper _mapper = mapper;

        public async Task<PlayRepresentation> Handle(PlayCommand request, CancellationToken cancellationToken)
        {
            var opponent2 = request.Opponent2 is 0 ? _apiClient.GetRandomNumber()!.Result : request.Opponent2;

            var resultMessage = _winnerCalculation.CalculateWinner(request.Opponent1, opponent2);

            var playToAdd = new Models.Play 
            {
                CrationDate = DateTime.UtcNow, 
                Id = new Guid(), 
                Opponent1 = request.Opponent1,
                Opponent2 = opponent2,
                Results = resultMessage
            };

            await _playRepository.Play(playToAdd);

            var response = _mapper.Map<Models.Play, PlayRepresentation>(playToAdd!);

            return response;
        }

    }
}