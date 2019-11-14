using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Direction
    {
        public static Direction Create(string letter) =>
            AllByLetter.TryGetValue(letter, out var result)
                ? result
                : None;

        private static readonly Direction None  = new Direction("?", "?", "?");
        private static readonly Direction North = new Direction("N", "W", "E");
        private static readonly Direction East  = new Direction("E", "N", "S");
        private static readonly Direction South = new Direction("S", "E", "W");
        private static readonly Direction West  = new Direction("W", "S", "N");

        private static readonly Dictionary<string, Direction> AllByLetter =
            new[] {North, South, East, West}.ToDictionary(x => x.Letter);

        public string Letter { get; }

        private readonly string _leftLetter;
        private readonly string _rightLetter;

        public Direction Left  => Create(_leftLetter);
        public Direction Right => Create(_rightLetter);

        private Direction(string currentLetter, string leftLetter, string rightLetter)
        {
            Letter       = currentLetter;
            _leftLetter  = leftLetter;
            _rightLetter = rightLetter;
        }
    }
}