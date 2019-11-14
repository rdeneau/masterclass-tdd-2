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
        }
    }

    public class Direction
    {
        public static Direction Create(string letter)
        {
            return null;
        }
    }
}