using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace RPSLS.Tests.API.Customization
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base (() =>
        {
            var fixture = new Fixture().Customize(new CompositeCustomization(
                new AutoMoqCustomization { ConfigureMembers = true }
                ));

            return fixture;
        }){ }
    }
}
