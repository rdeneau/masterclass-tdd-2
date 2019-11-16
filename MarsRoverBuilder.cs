namespace MarsRoverKata
{
    public class MarsRoverBuilder
    {
        private string DirectionLetter { get; set; } = "?";

        private int LocationX { get; set; } = -1;
        private int LocationY { get; set; } = -1;

        private int GridWidth { get; set; } = int.MaxValue;
        private int GridHeight { get; set; } = int.MaxValue;

        private readonly ObstacleDetector obstacleDetector = new ObstacleDetector();

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

        public MarsRoverBuilder RegisterObstacleLocatedAt(int x, int y)
        {
            obstacleDetector.RegisterObstacleLocatedAt(x, y);
            return this;
        }

        public static implicit operator MarsRover(MarsRoverBuilder builder) =>
            builder.Build();

        private MarsRover Build() =>
            new MarsRover(
                Direction.Create(
                    DirectionLetter),
                Location.Create(
                    Coordinate.Create(LocationX, GridWidth - 1),
                    Coordinate.Create(LocationY, GridHeight - 1)),
                obstacleDetector);
    }
}