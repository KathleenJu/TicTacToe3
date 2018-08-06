namespace TicTacToe
{
    public class Coordinates
    {
        public int X { get; } // row
        public int Y { get; } // column
        public int Z { get; } // depth?
        
        public Coordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}