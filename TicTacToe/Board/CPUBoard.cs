using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class CPUBoard : IBoard
    {
        public int BoardSize { get; }
        private readonly List<Cell> _playedCells;
        public IEnumerable<Cell> PlayedCells => _playedCells;


        public CPUBoard()
        {
            BoardSize = 3;
            _playedCells = new List<Cell>();
        }

        public CPUBoard(int boardSize) : this()
        {
            BoardSize = boardSize;
        }

        public void UpdateBoard(Cell playerMove)
        {
            if (IsEmptyPosition(playerMove.Coordinates) && IsValidCoordinate(playerMove.Coordinates))
            {
                _playedCells.Add(playerMove);
            }
        }

        public bool IsEmptyPosition(Coordinates playerCoordinates)
        {
            var position = _playedCells.Where(cell => cell.Coordinates.X == playerCoordinates.X && cell.Coordinates.Y == playerCoordinates.Y &&
                cell.Coordinates.Z == playerCoordinates.Z);

            return !position.Any() ? true : throw new BoardPositionIsOccupiedException("Position is already occupied by " + position.Select(c => c.State));
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            var isValidCoordinate = coordinates.X < BoardSize && coordinates.X >= 0 && coordinates.Y < BoardSize &&
                                    coordinates.Y >= 0;
            return isValidCoordinate? true : throw new CoordinateIsOutOfBoundsException("Coordinate is out of bounds.");
        }
    }
}