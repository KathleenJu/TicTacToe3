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
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(row, 0, depth));
            board.UpdateBoard('X', new Coordinates(row, 2, depth));
            board.UpdateBoard('X', new Coordinates(row, 1, depth));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningRow()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(0, 2, 0));
            board.UpdateBoard('X', new Coordinates(0, 0, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
        
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRowWithDifferentDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(0, 1, 1));
            board.UpdateBoard('X', new Coordinates(0, 2, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }
        
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRowWithDifferentDepthWithFirstRowAtTheBackLayer()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 2));
            board.UpdateBoard('X', new Coordinates(0, 1, 1));
            board.UpdateBoard('X', new Coordinates(0, 2, 0));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningRowWithDifferentDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(0, 1, 0));
            board.UpdateBoard('X', new Coordinates(0, 2, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);


            Assert.False(hasWinner);
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        public void ReturnWinnerWhenThereIsAWinningColumnWithSameDepth(int column, int depth)
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(1, column, depth));
            board.UpdateBoard('X', new Coordinates(0, column, depth));
            board.UpdateBoard('X', new Coordinates(2, column, depth));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningColumnWithSameDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(1, 0, 0));
            board.UpdateBoard('X', new Coordinates(0, 0, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningColumnWithDifferentDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(1, 0, 1));
            board.UpdateBoard('X', new Coordinates(2, 0, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningColumnWithDifferentDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(1, 1, 2));
            board.UpdateBoard('X', new Coordinates(0, 1, 0));
            board.UpdateBoard('X', new Coordinates(2, 1, 0));
            board.UpdateBoard('X', new Coordinates(2, 0, 1));
            board.UpdateBoard('X', new Coordinates(2, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 0, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);


            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(1, 2, 0));
            board.UpdateBoard('X', new Coordinates(1, 2, 1));
            board.UpdateBoard('X', new Coordinates(1, 2, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }
        
        [Fact]
        public void ReturnFalseWhenThereIsNoWinningDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(1, 1, 0));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(1, 0, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }


        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalPrimaryDiagonalLineWithSameDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 1));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 2, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningVerticalPrimaryDiagonalLineWithSameDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 2, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalSecondaryDiagonalLineWithSameDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 2, 1));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 0, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningVerticalSecondaryDiagonalLineWithSameDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 2, 1));
            board.UpdateBoard('X', new Coordinates(1, 1, 2));
            board.UpdateBoard('X', new Coordinates(2, 0, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        } 

        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalPrimaryDiagonalLineFromTopLeftFrontToBottomRightBack()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 2, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalPrimaryDiagonalLineFromTopLeftBackToBottomFront()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 2));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 2, 0));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningVerticalPrimaryDiagonalLineWithDifferentDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 0, 0));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 2, 0));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnTrueWhenThereIsAWinningVerticalSecondaryDiagonalLineFromTop()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 2, 0));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 0, 2));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningVerticalSecondaryDiagonalLineWithDifferentDepth()
        {
            var board = new TicTacToeCPUBoard(3);
            board.UpdateBoard('X', new Coordinates(0, 2, 0));
            board.UpdateBoard('X', new Coordinates(1, 1, 1));
            board.UpdateBoard('X', new Coordinates(2, 0, 1));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
    }
}