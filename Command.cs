using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Command
    {
        public static Command Create(string letter) =>
            AllByLetter.TryGetValue(letter, out var result)
                ? result
                : None;

        private static readonly Command None     = new Command("?");
        private static readonly Command Left     = new Command("L");
        private static readonly Command Right    = new Command("R");
        private static readonly Command Forward  = new Command("F");
        private static readonly Command Backward = new Command("B");

        private static readonly Dictionary<string, Command> AllByLetter =
            new[] {Left, Right, Forward, Backward}.ToDictionary(x => x.Letter);

        public string Letter { get; }

        private Command(string letter)
        {
            Letter = letter;
        }
    }
}