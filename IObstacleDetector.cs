using MarsRoverKata.Positioning;

namespace MarsRoverKata
{
    public interface IObstacleDetector
    {
        bool DetectObstacleAt(Location nextLocation);
    }
}