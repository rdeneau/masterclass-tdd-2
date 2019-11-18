namespace MarsRoverKata
{
    public class NoMove : IMoveEvent
    {
        public static readonly NoMove Instance = new NoMove();

        public bool IsMoveBlocked => false;

        private NoMove() {}
    }
}