using AutoMapper;
using MediatR;
using RPSLS.Application.DTOs;
using RPSLS.Application.WinnerCalculations;
using RPSLS.Data.Computers;
using RPSLS.Data.Plays;
using RPSLS.Infrastructure.Clients.CodeChallenge;
using RPSLS.Models;
using System.Text.RegularExpressions;

namespace RPSLS.Application.Play.Commands
{
    public class PlayerVersusComputerHandler(IPlayerRepository playerRepository, IComputerRepository computerRepository,
                                             ICodeChallengeApiClient apiClient, IWinnerCalculation winnerCalculation) : IRequestHandler<PlayCommand, PlayRepresentation>
    {
        private readonly IPlayerRepository _playerRepository = playerRepository;
        private readonly ICodeChallengeApiClient _apiClient = apiClient;
        private readonly IComputerRepository _computerRepository = computerRepository;
        private readonly IWinnerCalculation _winnerCalculation = winnerCalculation;

        public async Task<PlayRepresentation> Handle(PlayCommand request, CancellationToken cancellationToken)
        {
            var responseMessageContent = _apiClient.GetRandomNumber()!.Result;

            var randomNumberGenerated = FindAndExtractNumberFromString(responseMessageContent);

            var playerToAdd = new Player { CrationDate = DateTime.UtcNow, Id = new Guid(), ChoiceId = request.Player };

            await _playerRepository.AddPlayer(playerToAdd);

            var computerToAdd = new Computer { CrationDate = DateTime.UtcNow, Id = new Guid(), ChoiceId = randomNumberGenerated };

            await _computerRepository.AddComputer(computerToAdd);

            var response = _winnerCalculation.CalculateWinner(request.Player, randomNumberGenerated);

            return GenerateResponse(response, request.Player, randomNumberGenerated);
        }

        private static PlayRepresentation GenerateResponse(int response, int opponent1, int opponent2)
        {
            return new PlayRepresentation
            {
                Player = opponent1,
                Computer = opponent2,
                Results = response == -1 ? "tie" : response == opponent1 ? "win" : "lose"
            };
        }

        private static int FindAndExtractNumberFromString(string responseMessageContent)
        {
            var resultString = Regex.Match(responseMessageContent, @"\d+").Value;
            var result = int.Parse(resultString);

            if (result > 5)
            {
                Random random = new();
                return random.Next(1, 5);
            }
            else
            {
                return result;
            }
        }
    }
}