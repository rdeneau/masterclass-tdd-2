namespace MarsRoverKata
{
    public class Coordinate
    {
        public int Value { get; private set; }

        private int Max { get; }
        private int Min { get; }

        public static Coordinate Create(int value, int max = int.MaxValue, int min = 0) =>
            new Coordinate(value, max, min);

        private Coordinate(int value, int max, int min)
        {
            Value = value;
            Max   = max;
            Min   = min;
        }

        public void Decrement() =>
            Value = Value == Min
                        ? Max
                        : Value - 1;

        public void Increment() =>
            Value = Value == Max
                        ? Min
                        : Value + 1;
    }
}