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

        [Theory]
        [InlineData(10)]
        public void Land_On_A_Planet_With_a_Given_Size(int size)
        {
            sut = MarsRover.ThatIs()
                           .OnGridOfSize(size);

            sut.Grid.Size.Should().Be(size);
        }

        [Theory(Skip = "TODO now!")]
        [InlineData(2, "N", 0, 0, 0, 2)]
        public void Wrap_From_Edge_To_The_Other_Moving_Forward(int gridSize, string direction,
                                                               int startX, int startY,
                                                               int endX, int endY)
        {
            sut = MarsRover.ThatIs()
                           .Facing(direction)
                           .LocatedAt(startX, startY)
                           .OnGridOfSize(gridSize);
            
        }

        [Fact(Skip = "TODO after")]
        public void Execute_Commands()
        {
            sut = MarsRover.ThatIs()
                           .Facing("N")
                           .LocatedAt(1, 1);

//            var commands = "FLF";
//            sut.Execute(commands);
        }
    }
}