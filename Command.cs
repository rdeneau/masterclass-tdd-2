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
                : Unknown;

        public  static readonly Command Unknown  = new Command("?", _ => NoMove.Instance);
        private static readonly Command Left     = new Command("L", x => x.RotateLeft());
        private static readonly Command Right    = new Command("R", x => x.RotateRight());
        private static readonly Command Forward  = new Command("F", x => x.MoveForward());
        private static readonly Command Backward = new Command("B", x => x.MoveBackward());

        private static readonly Dictionary<string, Command> AllByLetter =
            new[] {Left, Right, Forward, Backward}.ToDictionary(x => x.Letter);

        public string Letter { get; }

        public Func<IVehicle, IMoveEvent> Move { get; }

        private Command(string letter, Func<IVehicle, IMoveEvent> move)
        {
            Letter = letter;
            Move   = move;
        }
    }
}