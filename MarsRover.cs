namespace MarsRoverKata
{
    public class MarsRover
    {
        public static MarsRover HeadingTo(string directionLetter)
        {
            var direction = Direction.Create(directionLetter);
            return new MarsRover(direction);
        }

        public Direction Direction { get; }

        private MarsRover(Direction direction)
        {
            Direction = direction;
        }
    }
}