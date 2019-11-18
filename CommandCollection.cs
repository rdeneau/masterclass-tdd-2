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
            PrepareMoves(vehicle)
                .Where(IsMoveBlockedOrLast)
                .DefaultIfEmpty(NoMove.Instance)
                .First();

        private IEnumerable<IMoveEvent> PrepareMoves(IVehicle vehicle) =>
            Commands.Select(command => command.Move(vehicle));

        private bool IsMoveBlockedOrLast(IMoveEvent moveEvent, int index)
        {
            var isLast = index == Commands.Count - 1;
            var isStop = moveEvent?.IsMoveBlocked ?? false;
            return isStop || isLast;
        }
    }
}