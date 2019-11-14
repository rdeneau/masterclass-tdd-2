using System;

namespace MarsRoverKata
{
    public sealed class Location : IEquatable<Location>
    {
        public static Location Create(int x, int y) =>
            new Location
            {
                X = x,
                Y = y,
            };

        public int X { get; set; }
        public int Y { get; set; }

        private Location() {}

        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
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
                return (X * 397) ^ Y;
            }
        }
    }
}