using System;

namespace MarsRoverKata
{
    public class MoveIsPossible : IMoveEvaluation
    {
        public bool IsMoveBlocked => false;

        public Location NextLocation { get; }

        public MoveIsPossible(Location to)
        {
            NextLocation = to.Copy();
        }

        public IMoveEvent WhenPossible(Action move)
        {
            move();
            return this;
        }
    }
}