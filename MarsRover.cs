namespace MarsRoverKata
{
    /// <summary>
    /// Direction of coordinates:
    /// • X: West  -> East
    /// • Y: North -> South
    /// </summary>
    public class MarsRover
    {
        public static Builder ThatIs() => new Builder();

        public class Builder
        {
            private string DirectionLetter { get; set; } = "?";

            private int LocationX { get; set; } = -1;
            private int LocationY { get; set; } = -1;

            private int GridSize { get; set; } = int.MaxValue;

            public Builder Facing(string direction)
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

            public Builder OnGridOfSize(int gridSize)
            {
                GridSize = gridSize;
                return this;
            }

            public static implicit operator MarsRover(Builder builder) =>
                new MarsRover(
                    Direction.Create(
                        builder.DirectionLetter),
                    Location.Create(
                        builder.LocationX,
                        builder.LocationY),
                    Grid.Create(builder.GridSize));
        }

        public Direction Direction { get; private set; }

        public Location Location { get; }

        public Grid Grid { get; }

        private MarsRover(Direction direction, Location location, Grid grid)
        {
            Direction = direction;
            Location  = location;
            Grid = grid;
        }

        public void TurnLeft()     => Direction = Direction.Left;
        public void TurnRight()    => Direction = Direction.Right;
        public void MoveForward()  => Direction.Forward(Location);
        public void MoveBackward() => Direction.Backward(Location);
    }
}