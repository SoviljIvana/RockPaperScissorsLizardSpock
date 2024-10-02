using FluentValidation;

namespace RPSLS.API.Requests.Choices.Validators
{
    public class AddChoiceRequestValidator : AbstractValidator<AddChoiceRequest>
    {
        public AddChoiceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mandatory field.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is mandatory field.");
        }
    }
}
