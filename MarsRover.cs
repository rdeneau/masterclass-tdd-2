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

        public MarsRover(Direction direction, Location location)
        {
            Direction = direction;
            Location  = location;
        }

        public void RotateLeft()  => Direction = Direction.Left;
        public void RotateRight() => Direction = Direction.Right;

        public void MoveForward()  => Move(Direction.Forward);
        public void MoveBackward() => Move(Direction.Backward);

        private void Move(Action<Location> moveLocation)
        {
            var nextLocation = Location.Copy();
            moveLocation(nextLocation);
            Location = nextLocation;
        }

        public void ReceiveCommands(string commands) =>
            CommandCollection
                .Create(commands)
                .Guide(this);
    }
}