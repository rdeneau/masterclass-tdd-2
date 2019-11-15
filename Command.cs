using System;
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

        private static readonly Command None     = new Command("?", _ => {});
        private static readonly Command Left     = new Command("L", x => x.RotateLeft());
        private static readonly Command Right    = new Command("R", x => x.RotateRight());
        private static readonly Command Forward  = new Command("F", x => x.MoveForward());
        private static readonly Command Backward = new Command("B", x => x.MoveBackward());

        private static readonly Dictionary<string, Command> AllByLetter =
            new[] {Left, Right, Forward, Backward}.ToDictionary(x => x.Letter);

        public string Letter { get; }

        public Action<IVehicle> Move { get; }

        private Command(string letter, Action<IVehicle> move)
        {
            Letter = letter;
            Move   = move;
        }
    }
}