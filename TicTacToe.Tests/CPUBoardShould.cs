using System.Linq;
using TicTacToe.Exceptions;
using Xunit;

namespace TicTacToe.Tests
{
    public class CPUBoardShould
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 0, 1)]
        public void UpdatesBoardIfPositionIsValidAndNotOccupied(int row, int column, int depth)
        {
            var board = new TicTacToeCPUBoard(3);
            var coordinates = new Coordinates(row, column, depth);
            var playerMove = new Cell('X', coordinates);
            board.UpdateBoard('X', coordinates);
            var boardUpdated = board.GetPlayedCells().Any(cell =>
                cell.State == playerMove.State && cell.Coordinates.Row == playerMove.Coordinates.Row &&
                cell.Coordinates.Column == playerMove.Coordinates.Column &&
                cell.Coordinates.Depth == playerMove.Coordinates.Depth);

            Assert.NotNull(board.GetPlayedCells());
            Assert.True(boardUpdated);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 0, 1)]
        public void ReturnExceptionIfPositionIsOccupied(int row, int column, int depth)

        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(row, column, depth));

            Assert.Throws<BoardPositionIsOccupiedException>(() => board.UpdateBoard('X', new Coordinates(row, column, depth)));
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, 3, -1)]
        [InlineData(2, 4, 0)]
        public void ReturnExceptionIfCoordinatesIsOutOfBounds(int row, int column, int depth)
        {
            var board = new TicTacToeCPUBoard(3);

            Assert.Throws<CoordinateIsOutOfBoundsException>(() => board.UpdateBoard('X', new Coordinates(row, column, depth)));
        }
    }
}