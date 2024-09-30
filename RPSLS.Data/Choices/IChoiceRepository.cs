using RPSLS.Models;

namespace RPSLS.Data.Choices
{
    public interface IChoiceRepository
    {
        Task<List<Choice>> GetAllChoices();
        Task<Choice> GetChoiceById(int id);
        Task<Choice> AddChoice(Choice choice);
    }
}
