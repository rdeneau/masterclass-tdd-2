using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public abstract class Direction
    {
        public static Direction Create(string letter) =>
            AllByLetter.TryGetValue(letter, out var result)
                ? result
                : null;

        private static readonly Direction North = new NorthDirection();

        private static readonly Dictionary<string, Direction> AllByLetter =
            new[] { North }.ToDictionary(x => x.Letter);

        public abstract string Letter { get; }

        private Direction() {}

        private sealed class NorthDirection : Direction
        {
            public override string Letter => "N";
        }
    }
}