namespace TicTacToe
{
    public class Cell
    {
        public char State { get; }
        public Coordinates Coordinates { get; }
        
        public Cell(char state, Coordinates coordinates)
        {
            State = state;
            Coordinates = coordinates;
        }
    }
}