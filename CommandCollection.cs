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
                .Select(x => Command.Create($"{x}"))
                .Where(x => x != Command.Unknown));

        public IReadOnlyList<Command> Commands { get; }

        private CommandCollection(IEnumerable<Command> commands)
        {
            Commands = commands.ToList();
        }

        public IMoveEvent Guide(IVehicle vehicle)
        {
            IMoveEvent moveEvent = NoMove.Instance;
            foreach (var command in Commands)
            {
                moveEvent = command.Move(vehicle);
                if (moveEvent is MoveIsHinderedByAnObstacle)
                {
                    break;
                }
            }
            return moveEvent;
        }
    }
}