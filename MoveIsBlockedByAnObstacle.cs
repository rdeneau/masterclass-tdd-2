using System;

namespace MarsRoverKata
{
    public class MoveIsBlockedByAnObstacle : IMoveEvaluation
    {
        public bool IsMoveBlocked => true;

        public Location Obstacle { get; }

        public MoveIsBlockedByAnObstacle(Location obstacle)
        {
            Obstacle = obstacle.Copy();
        }

        public IMoveEvent WhenPossible(Action move)
        {
            return this;
        }
    }
}