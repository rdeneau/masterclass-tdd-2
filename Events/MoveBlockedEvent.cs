using MarsRoverKata.Positioning;

namespace MarsRoverKata.Events
{
    public class MoveBlockedEvent : IVehicleEvent
    {
        public Location Obstacle { get; }

        public MoveBlockedEvent(Location obstacle)
        {
            Obstacle = obstacle;
        }
    }
}