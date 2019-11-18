using System.Collections.Generic;

namespace MarsRoverKata
{
    public class ObstacleDetector
    {
        private readonly List<Location> _obstacles = new List<Location>();

        public void RegisterObstacleLocatedAt(int x, int y)
        {
            _obstacles.Add(Location.Create(x, y));
        }

        public IMoveEvaluation EvaluateMoveTo(Location nextLocation)
        {
            if (_obstacles.Contains(nextLocation))
                return new MoveIsBlockedByAnObstacle(nextLocation);
            else
                return new MoveIsPossible(nextLocation);
        }
    }
}