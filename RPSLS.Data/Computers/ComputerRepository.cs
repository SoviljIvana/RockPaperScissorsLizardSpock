using RPSLS.Models;

namespace RPSLS.Data.Computers
{
    public class ComputerRepository(ApiDbContext apiDbContext) : IComputerRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<Computer> AddComputer(Computer computer)
        {
            var result = _apiDbContext.Computers?.Add(computer)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity);
        }
    }
}