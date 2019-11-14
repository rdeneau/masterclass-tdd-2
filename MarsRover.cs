namespace MarsRoverKata
{
    public class MarsRover
    {
        public static MarsRover HeadingTo(string directionLetter)
        {
            var direction = Direction.Create(directionLetter);
            return new MarsRover(direction);
        }

        public static MarsRover LocatedAt(int x, int y)
        {
            return HeadingTo("N"); //.WithLocation(x, y);
        }

        public Direction Direction { get; private set; }

        public Location Location { get; } = new Location(1, 1);

        private MarsRover(Direction direction)
        {
            Direction = direction;
        }

        public void TurnLeft()  => Direction = Direction.Left;
        public void TurnRight() => Direction = Direction.Right;
    }
}