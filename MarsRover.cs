using System;
using MarsRoverKata.Commands;
using MarsRoverKata.Events;
using MarsRoverKata.Positioning;

namespace MarsRoverKata
{
    /// <summary>
    /// Direction of coordinates:
    /// • X: West  -> East
    /// • Y: North -> South
    /// </summary>
    public class MarsRover : IVehicle
    {
        public static MarsRoverBuilder ThatIs() => new MarsRoverBuilder();

        public Direction Direction { get; private set; }

        public Location Location { get; private set; }

        private IObstacleDetector ObstacleDetector { get; }

        public MarsRover(Direction direction, Location location, IObstacleDetector obstacleDetector)
        {
            Direction        = direction;
            Location         = location;
            ObstacleDetector = obstacleDetector;
        }

        public IVehicleEvent RotateLeft()  => Rotate(Direction.Left);
        public IVehicleEvent RotateRight() => Rotate(Direction.Right);

        private IVehicleEvent Rotate(Direction direction)
        {
            Direction = direction;
            return new RotateEvent();
        }

        public IVehicleEvent MoveForward()  => TryMove(Direction.Forward);
        public IVehicleEvent MoveBackward() => TryMove(Direction.Backward);

        private IVehicleEvent TryMove(Action<Location> move)
        {
            var nextLocation = LocationAfter(move);
            if (ObstacleDetector.HasObstacleAt(nextLocation))
            {
                return new MoveBlockedEvent(nextLocation);
            }

            Location = nextLocation;
            return new MoveEvent();
        }

        private Location LocationAfter(Action<Location> move)
        {
            var nextLocation = Location.Copy();
            move(nextLocation);
            return nextLocation;
        }

        public IVehicleEvent ReceiveCommands(string commands) =>
            CommandCollection
                .Create(commands)
                .Guide(this);
    }
}