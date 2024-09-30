using RPSLS.Models;

namespace RPSLS.Data.Plays
{
    public class PlayerRepository(ApiDbContext apiDbContext) : IPlayerRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<Player> AddPlayer(Player player)
        {
            var result = _apiDbContext.Players?.Add(player)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity);
        }


    }
}
