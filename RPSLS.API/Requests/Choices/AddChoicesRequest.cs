using System.Diagnostics.CodeAnalysis;

namespace RPSLS.API.Requests.Choices
{
    [ExcludeFromCodeCoverage]
    public class AddChoicesRequest
    {
        public List<AddChoiceRequest>? Choices { get; set; }

    }
}
