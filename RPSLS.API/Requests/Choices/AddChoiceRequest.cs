using System.Diagnostics.CodeAnalysis;

namespace RPSLS.API.Requests.Choices
{
    [ExcludeFromCodeCoverage]
    public class AddChoiceRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
