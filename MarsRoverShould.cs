using FluentAssertions;
using Xunit;

namespace MarsRoverKata
{
    public class MarsRoverShould
    {
        [Theory]
        [InlineData("N")]
        public void Have_An_Initial_Direction(string directionLetter)
        {
            var direction = Direction.Create(directionLetter);
            var sut = new MarsRovers(direction);
            sut.Direction.Should().Be(Direction.North);
        }
    }
}