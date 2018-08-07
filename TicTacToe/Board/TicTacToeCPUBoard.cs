using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class TicTacToeCPUBoard : ITicTacToeBoard
    {
        private readonly int _boardSize;
        private readonly List<Cell> _playedCells;

        public TicTacToeCPUBoard()
        {
            _boardSize = 3;
            _playedCells = new List<Cell>();
        }

        public TicTacToeCPUBoard(int boardSize) : this()
        {
            _boardSize = boardSize;
        }

        public void UpdateBoard(char mark, Coordinates coordinates)
        {
            if (!IsEmptyPosition(coordinates))
            {
                throw new BoardPositionIsOccupiedException("Position is already occupied by " + mark);
            }

            if (!IsValidCoordinate(coordinates))
            {
                throw new CoordinateIsOutOfBoundsException("Coordinate is out of bounds.");
            }

            var cell = new Cell(mark, coordinates);
            _playedCells.Add(cell);
        }

        public bool IsEmptyPosition(Coordinates playerCoordinates)
        {
            return !_playedCells.Any(cell =>
                cell.Coordinates.Row == playerCoordinates.Row && cell.Coordinates.Column == playerCoordinates.Column &&
                cell.Coordinates.Depth == playerCoordinates.Depth);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            return coordinates.Row < _boardSize && coordinates.Row >= 0 && coordinates.Column < _boardSize &&
                   coordinates.Column >= 0;
        }

        public int GetBoardSize()
        {
            return _boardSize;
        }

        public List<Cell> GetPlayedCells()
        {
            return _playedCells;
        }
    }
}