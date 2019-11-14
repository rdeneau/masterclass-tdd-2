using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public sealed class Direction
    {
        public static Direction Create(string letter) =>
            AllByLetter.TryGetValue(letter, out var result)
                ? result
                : None;

        private static readonly Direction None  = new Direction("?", "?", "?", l => {}, l => {});
        private static readonly Direction North = new Direction("N", "W", "E", l => l.Y--, l => l.Y++);
        private static readonly Direction East  = new Direction("E", "N", "S", l => l.X++, l => l.X--);
        private static readonly Direction South = new Direction("S", "E", "W", l => l.Y++, l => l.Y--);
        private static readonly Direction West  = new Direction("W", "S", "N", l => l.X--, l => l.X++);

        private static readonly Dictionary<string, Direction> AllByLetter =
            new[] {North, South, East, West}.ToDictionary(x => x.Letter);

        public string Letter { get; }

        private readonly string _leftLetter;
        private readonly string _rightLetter;

        public Direction Left  => Create(_leftLetter);
        public Direction Right => Create(_rightLetter);

        public Action<Location> Forward { get; }
        public Action<Location> Backward { get; }

        private Direction(string currentLetter, string leftLetter, string rightLetter,
                          Action<Location> forward, Action<Location> backward)
        {
            Letter       = currentLetter;
            _leftLetter  = leftLetter;
            _rightLetter = rightLetter;

            Forward  = forward;
            Backward = backward;
        }
    }
}