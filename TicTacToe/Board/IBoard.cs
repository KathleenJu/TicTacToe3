namespace TicTacToe
{
    public interface IBoard
    {
        void UpdateBoard(Cell playerMove);
        bool IsEmptyPosition(Coordinates coordinates);
        bool IsValidCoordinate(Coordinates coordinates);
    }
}