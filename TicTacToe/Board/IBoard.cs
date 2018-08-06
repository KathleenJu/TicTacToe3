namespace TicTacToe
{
    public interface IBoard
    {
        void UpdateBoard(Cell playerMove);
        bool IsEmptyPosition(Coordinates playerCoordinates);
        bool IsValidCoordinate(Coordinates coordinates);
    }
}