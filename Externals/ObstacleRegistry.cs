using System.Collections.Generic;
using MarsRoverKata.Positioning;

namespace MarsRoverKata.Externals
{
    public class ObstacleRegistry : IObstacleDetector
    {
        private readonly List<Location> _obstacles = new List<Location>();

        public void RegisterObstacleLocatedAt(int x, int y)
        {
            _obstacles.Add(Location.Create(x, y));
        }

        public bool DetectObstacleAt(Location nextLocation) =>
            _obstacles.Contains(nextLocation);
    }
}