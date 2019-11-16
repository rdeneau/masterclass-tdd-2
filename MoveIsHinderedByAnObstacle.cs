using System;

namespace MarsRoverKata
{
    public class MoveIsHinderedByAnObstacle : IMoveEvent
    {
        public Location Obstacle { get; }

        public MoveIsHinderedByAnObstacle(Location obstacle)
        {
            Obstacle = obstacle.Copy();
        }

        public IMoveEvent MoveWhenPossible(Action move)
        {
            return this;
        }
    }
}