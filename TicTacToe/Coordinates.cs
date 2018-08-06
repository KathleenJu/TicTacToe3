namespace TicTacToe
{
    public class Coordinates
    {
        public int Row { get; } // row
        public int Column { get; } // column
        public int Depth { get; } // depth?
        
        public Coordinates(int row, int column, int depth)
        {
            Row = row;
            Column = column;
            Depth = depth;
        }
    }
}