using MarsRoverKata.Events;

namespace MarsRoverKata
{
    public interface IVehicle
    {
        IVehicleEvent RotateLeft();
        IVehicleEvent RotateRight();
        IVehicleEvent MoveForward();
        IVehicleEvent MoveBackward();
    }
}