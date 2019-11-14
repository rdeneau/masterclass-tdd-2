namespace MarsRoverKata
{
    public class Direction
    {
        public static Direction Create(string letter)
        {
            return null;
        }

        public static readonly Direction North = new NorthDirection();

        private Direction() {}

        private sealed class NorthDirection : Direction
        {
        }
    }
}