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

        public IMoveEvent Guide(IVehicle vehicle) =>
            Commands.Select(command => command.Move(vehicle))
                    .Where((moveEvent, index) =>
                    {
                        var isLast = index == Commands.Count - 1;
                        var isStop = moveEvent?.IsMoveBlocked ?? false;
                        return isStop || isLast;
                    })
                    .DefaultIfEmpty(NoMove.Instance)
                    .First();
    }
}