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
            sut = MarsRover.ThatIs().Facing(directionLetter);
            sut.Direction.Letter.Should().Be(directionLetter);
        }

        [Theory]
        [InlineData("N", "W")]
        [InlineData("W", "S")]
        [InlineData("S", "E")]
        [InlineData("E", "N")]
        public void Turn_Left(string startDirection, string endDirection)
        {
            sut = MarsRover.ThatIs().Facing(startDirection);
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
            sut = MarsRover.ThatIs().Facing(startDirection);
            sut.TurnRight();
            sut.Direction.Letter.Should().Be(endDirection);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        public void Have_An_Initial_Location(int x, int y)
        {
            sut = MarsRover.ThatIs().LocatedAt(x, y);
            sut.Location.Should().Be(Location.Create(x, y));
        }

        [Theory]
        [InlineData("N", 1, 0)]
        [InlineData("S", 1, 2)]
        [InlineData("W", 0, 1)]
        [InlineData("E", 2, 1)]
        public void Move_Forward_One_Time_To_Its_Direction(string direction, int endX, int endY)
        {
            sut = MarsRover.ThatIs()
                           .Facing(direction)
                           .LocatedAt(1, 1);

            sut.MoveForward();

            sut.Location.Should().Be(Location.Create(endX, endY));
        }

        [Theory]
        [InlineData("S", 1, 0)]
        [InlineData("N", 1, 2)]
        [InlineData("E", 0, 1)]
        [InlineData("W", 2, 1)]
        public void Move_Backward_One_Time_To_Its_Direction(string direction, int endX, int endY)
        {
            sut = MarsRover.ThatIs()
                           .Facing(direction)
                           .LocatedAt(1, 1);

            sut.MoveBackward();

            sut.Location.Should().Be(Location.Create(endX, endY));
        }
    }
}