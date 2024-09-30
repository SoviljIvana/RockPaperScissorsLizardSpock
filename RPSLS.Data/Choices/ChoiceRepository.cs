using RPSLS.Models;

namespace RPSLS.Data.Choices
{
    public class ChoiceRepository(ApiDbContext apiDbContext) : IChoiceRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<List<Choice>> GetAllChoices()
        {
            return Task.Run(() => GetQueryable().ToList())!;
        }

        public Task<Choice> GetChoiceById(int id)
        {
            var choice = _apiDbContext.Choices?.FirstOrDefault(x => x.Id == id);

            return Task.Run(() => choice)!;
        }

        public Task<Choice> AddChoice(Choice choice)
        {
            var result = _apiDbContext.Choices?.Add(choice)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity);
        }

        private IQueryable<Choice?> GetQueryable()
        {
            var choices = _apiDbContext.Choices;

            return choices;
        }
    }
}