namespace MarsRoverKata
{
    /// <summary>
    /// Direction of coordinates:
    /// • X: West  -> East
    /// • Y: North -> South
    /// </summary>
    public class MarsRover
    {
        public static MarsRoverBuilder ThatIs() => new MarsRoverBuilder();

        public Direction Direction { get; private set; }

        public Location Location { get; }

        public MarsRover(Direction direction, Location location)
        {
            Direction = direction;
            Location  = location;
        }

        public void TurnLeft()     => Direction = Direction.Left;
        public void TurnRight()    => Direction = Direction.Right;
        public void MoveForward()  => Direction.Forward(Location);
        public void MoveBackward() => Direction.Backward(Location);
    }
}