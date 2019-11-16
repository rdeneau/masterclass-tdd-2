using System;

namespace MarsRoverKata
{
    public class MoveIsHinderedByAnObstacle : IMoveEvaluation
    {
        public Location Obstacle { get; }

        public MoveIsHinderedByAnObstacle(Location obstacle)
        {
            Obstacle = obstacle.Copy();
        }

        public IMoveEvent WhenPossible(Action move)
        {
            return this;
        }
    }
}