using System;

namespace MarsRoverKata
{
    public interface IMoveEvent
    {
        IMoveEvent MoveWhenPossible(Action move);
    }
}