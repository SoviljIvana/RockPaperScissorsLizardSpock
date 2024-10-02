using FluentAssertions;
using FluentValidation.TestHelper;
using RPSLS.API.Requests.Choices;
using RPSLS.API.Requests.Choices.Validators;
using RPSLS.Tests.API.Customization;
using Xunit;

namespace RPSLS.Tests.API.Requests.Choices.Validators
{
    public class AddChoiceRequestValidatorTests
    {
        [Theory]
        [AutoMoqData]
        public void ShouldFail_When_NameIsEmpty(AddChoiceRequestValidator sut, AddChoiceRequest request)
        {
            // Arrange
            request.Name = "";

            // Act
            var result = sut.TestValidate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors[0].ErrorMessage.Should().Be("Name is mandatory field.");
        }

        [Theory]
        [AutoMoqData]
        public void ShouldFail_When_IdIsEmpty(AddChoiceRequestValidator sut)
        {
            // Arrange
            AddChoiceRequest request = new()
            {
                Name = "paper"
            };

            // Act
            var result = sut.TestValidate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors[0].ErrorMessage.Should().Be("Id is mandatory field.");
        }
    }
}
