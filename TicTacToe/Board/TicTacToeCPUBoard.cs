using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class TicTacToeCPUBoard : ITicTacToeBoard
    {
        private readonly int BoardSize;
        private readonly List<Cell> _playedCells;
        public IEnumerable<Cell> PlayedCells => _playedCells;

        public TicTacToeCPUBoard()
        {
            BoardSize = 3;
            _playedCells = new List<Cell>();
        }

        public TicTacToeCPUBoard(int boardSize) : this()
        {
            BoardSize = boardSize;
        }

        public void UpdateBoard(Cell playerMove)
        {
            if (!IsEmptyPosition(playerMove.Coordinates))
            {
                throw new BoardPositionIsOccupiedException("Position is already occupied by" + playerMove.State);
            }

            if (!IsValidCoordinate(playerMove.Coordinates))
            {
                throw new CoordinateIsOutOfBoundsException("Coordinate is out of bounds.");
            }

            _playedCells.Add(playerMove);
        }

        public bool IsEmptyPosition(Coordinates playerCoordinates)
        {
            var position = _playedCells.Where(cell =>
                cell.Coordinates.Row == playerCoordinates.Row && cell.Coordinates.Column == playerCoordinates.Column &&
                cell.Coordinates.Depth == playerCoordinates.Depth);

            return !position.Any();
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            return coordinates.Row < BoardSize && coordinates.Row >= 0 && coordinates.Column < BoardSize &&
                   coordinates.Column >= 0;
        }

        public int GetBoardSize()
        {
            return BoardSize;
        }

        public List<Cell> GetPlayedCells()
        {
            return _playedCells;
        }
    }
}