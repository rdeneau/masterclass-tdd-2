using FluentAssertions;
using Xunit;

namespace MarsRoverKata
{
    public class MarsRoverShould
    {
        private MarsRover sut;

        [Theory]
        [InlineData("N")]
        [InlineData("S")]
        [InlineData("E")]
        [InlineData("W")]
        public void Have_An_Initial_Direction(string directionLetter)
        {
            sut = MarsRover.ThatIs().HeadingTo(directionLetter);
            sut.Direction.Letter.Should().Be(directionLetter);
        }

        [Theory]
        [InlineData("N", "W")]
        [InlineData("W", "S")]
        [InlineData("S", "E")]
        [InlineData("E", "N")]
        public void Turn_Left(string startDirection, string endDirection)
        {
            sut = MarsRover.ThatIs().HeadingTo(startDirection);
            sut.TurnLeft();
            sut.Direction.Letter.Should().Be(endDirection);
        }

        [Theory]
        [InlineData("W", "N")]
        [InlineData("S", "W")]
        [InlineData("E", "S")]
        [InlineData("N", "E")]
        public void Turn_Right(string startDirection, string endDirection)
        {
            sut = MarsRover.ThatIs().HeadingTo(startDirection);
            sut.TurnRight();
            sut.Direction.Letter.Should().Be(endDirection);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        public void Have_An_Initial_Location(int x, int y)
        {
            sut = MarsRover.ThatIs().LocatedAt(x, y);
            sut.Location.X.Should().Be(x);
            sut.Location.Y.Should().Be(y);
        }
    }
}