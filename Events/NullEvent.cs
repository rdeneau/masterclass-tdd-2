namespace MarsRoverKata.Events
{
    public class NullEvent : IVehicleEvent
    {
        public static readonly NullEvent Instance = new NullEvent();

        public bool IsMoveBlocked => false;

        private NullEvent() {}
    }
}