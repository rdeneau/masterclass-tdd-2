using System.Collections.Generic;
using System.Linq;
using MarsRoverKata.Events;

namespace MarsRoverKata.Commands
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

        public IVehicleEvent Guide(IVehicle vehicle) =>
            PrepareMoves(vehicle)
                .Where(IsMoveBlockedOrLast)
                .DefaultIfEmpty(NullEvent.Instance)
                .First();

        private IEnumerable<IVehicleEvent> PrepareMoves(IVehicle vehicle) =>
            Commands.Select(command => command.Move(vehicle));

        private bool IsMoveBlockedOrLast(IVehicleEvent moveEvent, int index)
        {
            var blocked = moveEvent is MoveBlockedEvent;
            var isLast  = index == Commands.Count - 1;
            return blocked || isLast;
        }
    }
}