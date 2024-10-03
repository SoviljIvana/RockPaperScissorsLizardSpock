namespace RPSLS.Infrastructure.Clients.CodeChallenge
{
    public interface ICodeChallengeApiClient
    {
        Task<int> GetRandomNumber();
    }
}
