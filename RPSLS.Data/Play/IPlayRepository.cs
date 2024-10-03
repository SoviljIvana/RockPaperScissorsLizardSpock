using RPSLS.Models;

namespace RPSLS.Data.Plays
{
    public interface IPlayRepository
    {
        Task<Play> Play(Play play);
    }
}
