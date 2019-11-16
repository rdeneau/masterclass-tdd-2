using System;

namespace MarsRoverKata
{
    public class MoveIsPossible : IMoveEvaluation
    {
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