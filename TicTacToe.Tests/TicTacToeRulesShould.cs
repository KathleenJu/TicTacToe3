using TicTacToe.Rules;
using Xunit;

namespace TicTacToe.Tests
{
    public class TicTacToeRulesShould
    {
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningRow()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(2, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 1, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningColumn()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnWinnerWhenThereIsAWinningPrimaryDiagonal()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        } 
        
        [Fact]
        public void ReturnWinnerWhenThereIsAWinningSecondaryDiagonal()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 1, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 0, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.True(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenThereIsNoWinningLines()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(1, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 0, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }

        [Fact]
        public void ReturnFalseWhenBoardIsFullAndThereIsNoWinner()
        {
            var board = new CPUBoard(3);
            board.UpdateBoard(new Cell('X', new Coordinates(0, 0, 0)));
            board.UpdateBoard(new Cell('O', new Coordinates(0, 1, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(0, 2, 0)));
            board.UpdateBoard(new Cell('O', new Coordinates(1, 0, 0)));
            board.UpdateBoard(new Cell('O', new Coordinates(1, 1, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(1, 2, 0)));
            board.UpdateBoard(new Cell('O', new Coordinates(2, 0, 0)));
            board.UpdateBoard(new Cell('X', new Coordinates(2, 1, 0)));
            board.UpdateBoard(new Cell('O', new Coordinates(2, 2, 0)));
            var rules = new TicTacToeRules();
            var hasWinner = rules.HasWinner(board);

            Assert.False(hasWinner);
        }
    }
}