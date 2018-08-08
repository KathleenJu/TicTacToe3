using System.Linq;
using Moq;
using Xunit;

namespace TicTacToe.Tests
{
    public class TicTacToeGameShould
    {
        [Theory]
        [InlineData('O', 1, 1, 0)]
        [InlineData('X', 0, 1, 0)]
        [InlineData('O', 2, 1, 2)]
        public void UpdatesBoardWhenMoveIsPlayed(char mark, int row, int column, int depth)
        {
            var game = new TicTacToeGame();
            var coordinates = new Coordinates(row, column, depth);
            game.PlayMove(mark, coordinates);
            var playedCells = game.GetGameBoard().GetPlayedCells();
            var boardUpdated = playedCells.Last().State == 'X' && playedCells.Last().Coordinates == coordinates;

            Assert.True(boardUpdated);
        }

        [Fact]
        public void ReturnGameIsOverWhenThereIsAWinner()
        {
            var game = new TicTacToeGame();
            game.PlayMove('X', new Coordinates(0,0,0));
            game.PlayMove('O', new Coordinates(0,1,1));
            game.PlayMove('X', new Coordinates(1,1,0));
            game.PlayMove('X', new Coordinates(2,2,0));
            var hasWinner = game.IsGameOver();
            
            Assert.True(hasWinner);
        }
        
        [Fact]
        public void ReturnGameIsOverWhenGameIsADraw()
        {
            var game = new TicTacToeGame();
            game.PlayMove('E', new Coordinates(0,0,0));
            game.PlayMove('W', new Coordinates(0,0,1));
            game.PlayMove('Q', new Coordinates(0,0,2));
            game.PlayMove('T', new Coordinates(0,1,0));
            game.PlayMove('F', new Coordinates(0,1,1));
            game.PlayMove('X', new Coordinates(0,1,2));
            game.PlayMove('O', new Coordinates(0,2,0));
            game.PlayMove('X', new Coordinates(0,2,1));
            game.PlayMove('1', new Coordinates(0,2,2));
            game.PlayMove('P', new Coordinates(1,0,0));
            game.PlayMove('X', new Coordinates(1,0,1));
            game.PlayMove('G', new Coordinates(1,0,2));
            game.PlayMove('3', new Coordinates(1,1,0));
            game.PlayMove('4', new Coordinates(1,1,1));
            game.PlayMove('O', new Coordinates(1,1,2));
            game.PlayMove('N', new Coordinates(1,2,0));
            game.PlayMove('N', new Coordinates(1,2,1));
            game.PlayMove('R', new Coordinates(1,2,2));
            game.PlayMove('Y', new Coordinates(2,0,0));
            game.PlayMove('X', new Coordinates(2,0,1));
            game.PlayMove('O', new Coordinates(2,0,2));
            game.PlayMove('X', new Coordinates(2,1,0));
            game.PlayMove('S', new Coordinates(2,1,1));
            game.PlayMove('O', new Coordinates(2,1,2));
            game.PlayMove('N', new Coordinates(2,2,0));
            game.PlayMove('M', new Coordinates(2,2,1));
            game.PlayMove('B', new Coordinates(2,2,2));
            var hasWinner = game.IsGameOver();
            
            Assert.True(hasWinner);
        }
        
        [Fact]
        public void AddPlayerToGameIfMarkHasntBeenTakenByAnotherPlayer()
        {
            var game = new TicTacToeGame();
            var computerPlayer = new ComputerPlayer();
            game.AddPlayerToGame(computerPlayer);
            computerPlayer.SetPlayerMark();
            var computerPlayerMark = computerPlayer.GetPlayerMark();

            var hasMarkTakenByOtherPlayer = game.GetGamePlayers().Any(player => player.GetPlayerMark() == computerPlayerMark);
            Assert.True(hasMarkTakenByOtherPlayer);
        }
    }
}