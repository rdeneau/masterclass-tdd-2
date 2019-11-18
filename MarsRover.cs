using System;

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

        private ObstacleDetector ObstacleDetector { get; }

        public MarsRover(Direction direction, Location location, ObstacleDetector obstacleDetector)
        {
            Direction        = direction;
            Location         = location;
            ObstacleDetector = obstacleDetector;
        }

        public IMoveEvent RotateLeft()  => Rotate(Direction.Left);
        public IMoveEvent RotateRight() => Rotate(Direction.Right);

        private IMoveEvent Rotate(Direction direction)
        {
            Direction = direction;
            return new MoveIsPossible(Location);
        }

        public IMoveEvent MoveForward()  => Move(Direction.Forward);
        public IMoveEvent MoveBackward() => Move(Direction.Backward);

        private IMoveEvent Move(Action<Location> updateLocation)
        {
            var nextLocation   = NextLocation(updateLocation);
            var moveEvaluation = ObstacleDetector.EvaluateMoveTo(nextLocation);
            return moveEvaluation.WhenPossible(() => Location = nextLocation);
        }

        private Location NextLocation(Action<Location> moveLocation)
        {
            var nextLocation = Location.Copy();
            moveLocation(nextLocation);
            return nextLocation;
        }

        public IMoveEvent ReceiveCommands(string commands) =>
            CommandCollection
                .Create(commands)
                .Guide(this);
    }
}