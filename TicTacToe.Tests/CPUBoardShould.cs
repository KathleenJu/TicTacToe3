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
            var playerMove = new Cell('X', new Coordinates(row, column, depth));
            board.UpdateBoard(playerMove);
            var boardUpdated = board.GetPlayedCells().Contains(playerMove);
            
            Assert.True(boardUpdated);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 0, 1)]
        public void ReturnExceptionIfPositionIsOccupied(int row, int column, int depth)

        {
            var board = new TicTacToeCPUBoard(3);
            var playerMove = new Cell('X', new Coordinates(row, column, depth));
            board.UpdateBoard(playerMove);

            Assert.Throws<BoardPositionIsOccupiedException>(() => board.UpdateBoard(playerMove));
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, 3, -1)]
        [InlineData(2, 4, 0)]
        public void ReturnExceptionIfCoordinatesIsOutOfBounds(int row, int column, int depth)
        {
            var board = new TicTacToeCPUBoard(3);
            var playerMove = new Cell('X', new Coordinates(row, column, depth));
            board.UpdateBoard(playerMove);

            Assert.Throws<BoardPositionIsOccupiedException>(() => board.UpdateBoard(playerMove));
        }
    }
}