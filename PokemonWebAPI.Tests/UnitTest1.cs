using Xunit;
using FluentAssertions;

namespace PokemonWebAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var expectedResult = "test case";

            // Act
            var result = "test case";

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
