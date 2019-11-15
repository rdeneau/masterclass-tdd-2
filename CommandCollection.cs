using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class CommandCollection
    {
        public static CommandCollection Create(string letters) =>
            new CommandCollection(
                (letters ?? "")
                    .ToCharArray()
                    .Select(c => Command.Create($"{c}")));

        public IReadOnlyList<Command> Commands { get; }

        private CommandCollection(IEnumerable<Command> commands)
        {
            Commands = commands.ToList();
        }

        public void Guide(IVehicle vehicle)
        {
            foreach (var command in Commands)
            {
                command.Move(vehicle);
            }
        }
    }
}