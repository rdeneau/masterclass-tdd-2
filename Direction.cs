using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Direction
    {
        public static Direction Create(string letter) =>
            AllByLetter.TryGetValue(letter, out var result)
                ? result
                : null;

        private static readonly Direction North = new Direction("N");
        private static readonly Direction South = new Direction("S");

        private static readonly Dictionary<string, Direction> AllByLetter =
            new[] { North, South }.ToDictionary(x => x.Letter);

        public string Letter { get; }

        private Direction(string letter)
        {
            Letter = letter;
        }
    }
}