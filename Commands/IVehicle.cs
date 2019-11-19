using MarsRoverKata.Events;

namespace MarsRoverKata.Commands
{
    public interface IVehicle
    {
        IVehicleEvent RotateLeft();
        IVehicleEvent RotateRight();
        IVehicleEvent MoveForward();
        IVehicleEvent MoveBackward();
    }
}