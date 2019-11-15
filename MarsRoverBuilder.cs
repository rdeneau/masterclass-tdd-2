namespace MarsRoverKata
{
    public class MarsRoverBuilder
    {
        private string DirectionLetter { get; set; } = "?";

        private int LocationX { get; set; } = -1;
        private int LocationY { get; set; } = -1;

        private int GridWidth { get; set; } = int.MaxValue;
        private int GridHeight { get; set; } = int.MaxValue;

        public MarsRoverBuilder Facing(string direction)
        {
            DirectionLetter = direction;
            return this;
        }

        public MarsRoverBuilder LocatedAt(int x, int y)
        {
            LocationX = x;
            LocationY = y;
            return this;
        }

        public MarsRoverBuilder OnGrid(int width, int height)
        {
            GridWidth  = width;
            GridHeight = height;
            return this;
        }

        public static implicit operator MarsRover(MarsRoverBuilder builder) =>
            new MarsRover(
                Direction.Create(
                    builder.DirectionLetter),
                Location.Create(
                    Coordinate.Create(builder.LocationX, builder.GridWidth - 1),
                    Coordinate.Create(builder.LocationY, builder.GridHeight - 1)));
    }
}