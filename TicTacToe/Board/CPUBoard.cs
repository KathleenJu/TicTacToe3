using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class CPUBoard : IBoard
    {
        public int BoardSizeSize { get; }
        private readonly List<Cell> _playedCells;
        public IEnumerable<Cell> PlayedCells => _playedCells;
        
        
        public CPUBoard(List<Cell> playedCells)
        {
            BoardSizeSize = 3;
            _playedCells = playedCells;
        }

        public CPUBoard(int boardSize, List<Cell> playedCells): this(playedCells)
        {
            BoardSizeSize = boardSize;
        }

        public void UpdateBoard(Cell playerMove)
        {
            if (IsEmptyPosition(playerMove.Coordinates) && IsValidCoordinate(playerMove.Coordinates))
            {
                _playedCells.Add(playerMove);
            }
            // ??
        }

        public bool IsEmptyPosition(Coordinates playerCoordinates)
        {
            return _playedCells.Select(c => c.Coordinates).Any(coord => coord.X == playerCoordinates.X && coord.Y == playerCoordinates.Y && coord.Z == playerCoordinates.Z);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            throw new System.NotImplementedException();
        }
    }
}