using RPSLS.Models;

namespace RPSLS.Data.Computers
{
    public interface IComputerRepository
    {
        Task<Computer> AddComputer(Computer computer);
    }
}
