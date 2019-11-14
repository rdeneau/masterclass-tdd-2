using FluentAssertions;
using Xunit;

namespace MarsRoverKata
{
    public class MarsRoverShould
    {
        [Theory]
        [InlineData("N")]
        [InlineData("S")]
        [InlineData("E")]
        [InlineData("W")]
        public void Have_An_Initial_Direction(string directionLetter)
        {
            var sut = MarsRover.HeadingTo(directionLetter);
            sut.Direction.Letter.Should().Be(directionLetter);
        }

        [Theory]
        [InlineData("N", "W")]
        [InlineData("W", "S")]
        [InlineData("S", "E")]
        [InlineData("E", "N")]
        public void Turn_Left(string startDirection, string endDirection)
        {
            var sut = MarsRover.HeadingTo(startDirection);
            sut.TurnLeft();
            sut.Direction.Letter.Should().Be(endDirection);
        }
    }
}