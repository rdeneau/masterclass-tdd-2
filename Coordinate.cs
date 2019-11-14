using System;

namespace MarsRoverKata
{
    public class Coordinate : IEquatable<Coordinate>
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

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinate) obj);
        }

        public override int GetHashCode() => Value;
    }
}