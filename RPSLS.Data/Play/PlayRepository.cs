using RPSLS.Models;

namespace RPSLS.Data.Plays
{
    public class PlayRepository(ApiDbContext apiDbContext) : IPlayRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<Play> Play(Play play)
        {
            var result = _apiDbContext.Plays?.Add(play)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity);
        }
    }
}
