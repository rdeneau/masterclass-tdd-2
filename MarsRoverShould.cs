using FluentAssertions;
using MarsRoverKata.Events;
using MarsRoverKata.Positioning;
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
        public void Rotate_Left(string startDirection, string endDirection)
        {
            sut = MarsRover.ThatIs().Facing(startDirection);
            sut.RotateLeft();
            sut.Direction.Letter.Should().Be(endDirection);
        }

        [Theory]
        [InlineData("W", "N")]
        [InlineData("S", "W")]
        [InlineData("E", "S")]
        [InlineData("N", "E")]
        public void Rotate_Right(string startDirection, string endDirection)
        {
            sut = MarsRover.ThatIs().Facing(startDirection);
            sut.RotateRight();
            sut.Direction.Letter.Should().Be(endDirection);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        public void Have_An_Initial_Location(int x, int y)
        {
            sut = MarsRover.ThatIs().LocatedAt(x, y);
            ShouldBeLocatedAt(x, y);
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

            ShouldBeLocatedAt(endX, endY);
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

            ShouldBeLocatedAt(endX, endY);
        }

        [Fact]
        public void Stay_Still_When_Moving_On_1x1_Grid()
        {
            sut = MarsRover.ThatIs()
                           .LocatedAt(0, 0)
                           .OnGridOfSize(1, 1);

            sut.MoveForward();

            ShouldBeLocatedAt(0, 0);
        }

        [Theory]
        [InlineData("S", 1, 1, "FLF",    2, 2)]
        [InlineData("N", 1, 1, "FLF",    0, 0)]
        [InlineData("N", 0, 0, "BRFFRF", 2, 2)]
        public void Be_Guided_By_Received_Commands(
            string startDirection, int startX, int startY,
            string commands,       int endX,   int endY)
        {
            sut = MarsRover.ThatIs()
                           .Facing(startDirection)
                           .LocatedAt(startX, startY)
                           .OnGridOfSize(10, 10);

            sut.ReceiveCommands(commands);

            ShouldBeLocatedAt(endX, endY);
        }

        [Fact]
        public void Detect_Obstacle_At_Next_Location_And_Prevent_Move()
        {
            sut = MarsRover.ThatIs()
                           .Facing("S")
                           .LocatedAt(0, 0)
                           .WithObstacleAt(0, 1);

            var moveEvent = sut.MoveForward();
            moveEvent.Should().BeOfType<MoveBlockedEvent>();

            ShouldBeLocatedAt(0, 0);
        }

        [Fact]
        public void Move_To_Next_Location_When_No_Obstacle_Is_Detected()
        {
            sut = MarsRover.ThatIs()
                           .Facing("S")
                           .LocatedAt(0, 0)
                           .WithObstacleAt(2, 2);

            var moveEvent = sut.MoveForward();
            moveEvent.Should().BeOfType<MoveEvent>();

            ShouldBeLocatedAt(0, 1);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 2)]
        public void Be_Guided_Until_Blocked_By_An_Obstacle_At(int x, int y)
        {
            sut = MarsRover.ThatIs()
                           .Facing("N")
                           .LocatedAt(0, 0)
                           .WithObstacleAt(x, y);

            var lastMoveEvent = sut.ReceiveCommands("BRFFRF");

            lastMoveEvent.Should().BeOfType<MoveBlockedEvent>()
                         .Which.Obstacle.Should().Be(Location.Create(x, y));
        }

        private void ShouldBeLocatedAt(int x, int y) =>
            sut.Location.Should().Be(Location.Create(x, y));
    }
}