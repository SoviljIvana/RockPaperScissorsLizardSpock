using RPSLS.Models;

namespace RPSLS.Data.Plays
{
    public interface IPlayerRepository
    {
        Task<Player> AddPlayer(Player player);
    }
}
