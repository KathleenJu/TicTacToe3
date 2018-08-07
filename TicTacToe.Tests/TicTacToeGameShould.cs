using System.Linq;
using Xunit;

namespace TicTacToe.Tests
{
    public class TicTacToeGameShould
    {
        [Fact]
        public void UpdatesBoardWhenMoveIsPlayed()
        {
            var game = new TicTacToeGame();
            var coordinates = new Coordinates(1, 1, 1);
            game.PlayMove('X', coordinates);
            var playedCells = game.GetGameBoard().GetPlayedCells();
            
            Assert.Equal(playedCells.Last(), new Cell('X', coordinates));
        }
    }
}