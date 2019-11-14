namespace MarsRoverKata
{
    public class MarsRover
    {
        public static Builder ThatIs() => new Builder();

        public class Builder
        {
            private string DirectionLetter { get; set; } = "?";

            private int LocationX { get; set; } = -1;
            private int LocationY { get; set; } = -1;

            public Builder HeadingTo(string direction)
            {
                DirectionLetter = direction;
                return this;
            }

            public Builder LocatedAt(int x, int y)
            {
                LocationX = x;
                LocationY = y;
                return this;
            }

            public static implicit operator MarsRover(Builder builder) =>
                new MarsRover(
                    Direction.Create(builder.DirectionLetter),
                    new Location(builder.LocationX, builder.LocationY));
        }

        public Direction Direction { get; private set; }

        public Location Location { get; }

        private MarsRover(Direction direction, Location location)
        {
            Direction = direction;
            Location  = location;
        }

        public void TurnLeft()  => Direction = Direction.Left;
        public void TurnRight() => Direction = Direction.Right;
    }
}