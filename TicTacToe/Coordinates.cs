namespace TicTacToe
{
    public class Coordinates
    {
        public int Row { get; } 
        public int Column { get; } 
        public int Depth { get; } 
        
        public Coordinates(int row, int column, int depth)
        {
            Row = row;
            Column = column;
            Depth = depth;
        }
    }
}