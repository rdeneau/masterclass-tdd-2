using System;

namespace MarsRoverKata
{
    public interface IMoveEvaluation : IMoveEvent
    {
        IMoveEvent WhenPossible(Action move);
    }
}