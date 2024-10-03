using AutoMapper;
using FluentAssertions;
using RPSLS.API.Common.Mappers;
using RPSLS.API.Requests.Choices;
using RPSLS.Application.Choices.Commands.AddChoices;
using RPSLS.Tests.API.Customization;
using Xunit;

namespace RPSLS.Tests.API.Common.Mappers
{
    public class ChoicesProfileMapperTests
    {
        [Theory]
        [AutoMoqData]
        public void ChoicesProfileMapper_ShouldMap_SourceToDestination(AddChoiceRequest source, ChoicesProfileMapper profileMapper)
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profileMapper));
            var mapper = new Mapper(configuration);

            // Act
            var result = mapper.Map<AddChoiceCommand>(source);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(source.Name);
            result.Id.Should().Be(source.Id);
        }
    }
}
