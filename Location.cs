using System;

namespace MarsRoverKata
{
    public sealed class Location : IEquatable<Location>
    {
        public static Location Create(int x, int y) =>
            new Location
            {
                X = Coordinate.Create(x),
                Y = Coordinate.Create(y),
            };

        public static Location Create(Coordinate x, Coordinate y) =>
            new Location
            {
                X = x,
                Y = y,
            };

        public Coordinate X { get; private set; }
        public Coordinate Y { get; private set; }

        private Location() {}

        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Location other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public override string ToString() =>
            $"{{ X: {X.Value}, Y: {Y.Value} }}";
    }
}