using TicTacToe.Rules;
using Xunit;

namespace TicTacToe.Tests
{
    public class TicTacToeRulesShould
    {
        [Theory]
        [InlineData(2, 0)]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        public void ReturnWinnerWhenThereIsAWinningRowWithSameDepth(int row, int depth)
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(row, 0, depth)));
            board.UpdateBoard(new Cell('X', new Coordinates(row, 2, depth)));
            board.UpdateBoard(new Cell('X', new Coordinates(row, 1, depth)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningRow()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(2, 0, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 1, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        public void ReturnWinnerWhenThereIsAWinningColumn(int column, int depth)
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, column, depth)));
            board.UpdateBoard(new Cell('X', new Coordinates(0, column, depth)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, column, depth)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningColumn()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 1)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
        
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningDepth()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningDepth()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 0, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
        

        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalPrimaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 0, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 1)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningVerticalPrimaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 1)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalSecondaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 0, 1)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningVerticalSecondaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 2)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 0, 1)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
        
        [Fact]
        public void ReturnTrueWhenThereIsAWinningHorizontalPrimaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 0, 2)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningHorizontalPrimaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
        
        [Fact]
        public void ReturnTrueWhenThereIsAWinningHorizontalSecondaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningHorizontalSecondaryDiagonalLine()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 1)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 2)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
    }
}