namespace MarsRoverKata
{
    public interface IVehicle
    {
        void RotateLeft();
        void RotateRight();
        IMoveEvent MoveForward();
        IMoveEvent MoveBackward();
    }
}