namespace MarsRoverKata
{
    public interface IVehicle
    {
        IMoveEvent RotateLeft();
        IMoveEvent RotateRight();
        IMoveEvent MoveForward();
        IMoveEvent MoveBackward();
    }
}