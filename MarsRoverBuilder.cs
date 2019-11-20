using System;
using MarsRoverKata.Externals;
using MarsRoverKata.Positioning;

namespace MarsRoverKata
{
    public class MarsRoverBuilder
    {
        private string DirectionLetter { get; set; } = "?";

        private int LocationX { get; set; } = -1;
        private int LocationY { get; set; } = -1;

        private int GridWidth { get; set; } = int.MaxValue;
        private int GridHeight { get; set; } = int.MaxValue;

        private readonly ObstacleRegistry obstacleRegistry = new ObstacleRegistry();

        public MarsRoverBuilder Facing(string direction) =>
            With(() => DirectionLetter = direction);

        public MarsRoverBuilder LocatedAt(int x, int y) =>
            With(() =>
            {
                LocationX = x;
                LocationY = y;
            });

        public MarsRoverBuilder OnGridOfSize(int width, int height) =>
            With(() =>
            {
                GridWidth  = width;
                GridHeight = height;
            });

        public MarsRoverBuilder WithObstacleAt(int x, int y) =>
            With(() => obstacleRegistry.RegisterObstacleLocatedAt(x, y));

        public static implicit operator MarsRover(MarsRoverBuilder builder) =>
            builder.Build();

        private MarsRover Build() =>
            new MarsRover(
                Direction.Create(
                    DirectionLetter),
                Location.Create(
                    Coordinate.Create(LocationX, GridWidth - 1),
                    Coordinate.Create(LocationY, GridHeight - 1)),
                obstacleRegistry);

        private MarsRoverBuilder With(Action action)
        {
            action();
            return this;
        }
    }
}