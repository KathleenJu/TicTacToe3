using System.Collections.Generic;

namespace TicTacToe
{
    public interface ITicTacToeBoard
    {
        void UpdateBoard(char mark, Coordinates coordinates);
        bool IsEmptyPosition(Coordinates playerCoordinates);
        bool IsValidCoordinate(Coordinates coordinates);
        int GetBoardSize();
        List<Cell> GetPlayedCells();
    }
}