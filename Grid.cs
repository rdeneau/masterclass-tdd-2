namespace MarsRoverKata
{
    public sealed class Grid
    {
        public static Grid Create(int size) =>
            new Grid(size);

        public int Size { get; }

        private Grid(int size)
        {
            Size = size;
        }
    }
}