using System.Collections.Generic;
using MarsRoverKata.Events;

namespace MarsRoverKata
{
    public class ObstacleDetector
    {
        private readonly List<Location> _obstacles = new List<Location>();

        public void RegisterObstacleLocatedAt(int x, int y)
        {
            _obstacles.Add(Location.Create(x, y));
        }

        public IVehicleEvent TryMoveVehicleTo(IMovable vehicle, Location nextLocation)
        {
            if (HasObstacleAt(nextLocation))
            {
                return new MoveBlockedEvent(nextLocation);
            }

            vehicle.MoveTo(nextLocation);
            return new MoveEvent();
        }

        private bool HasObstacleAt(Location nextLocation) =>
            _obstacles.Contains(nextLocation);
    }
}