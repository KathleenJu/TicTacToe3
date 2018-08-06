using Xunit;

namespace TicTacToe.Tests
{
    public class PlayerShould
    {
        [Fact]
        public void ReturnTheComputerPlayerMark()
        {
            var player = new ComputerPlayer();
            player.GetPlayerMark();
            
            Assert.NotNull(player.Mark);
        }
        
        
        public void ReturnTheComputerPlayerMove()
        {
            var player = new ComputerPlayer();
            var coord = player.GetPlayerMove();
            var actualOutput  = new Coordinates(1, 1, 1);
            
            Assert.Equal(coord, actualOutput);
        }
    }
}