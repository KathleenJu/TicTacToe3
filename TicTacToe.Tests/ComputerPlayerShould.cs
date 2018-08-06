using Xunit;

namespace TicTacToe.Tests
{
    public class ComputerPlayerShould
    {
        [Fact]
        public void ReturnTheComputerPlayerMark()
        {
            var player = new ComputerPlayer();
            player.SetPlayerMark();
            
            Assert.NotNull(player.Mark);
        }
        
       [Fact] 
        public void ReturnTheComputerPlayerMove()
        {
            var player = new ComputerPlayer();
            var coord = player.GetPlayerMove();
            
            Assert.NotNull(coord);
        }
    }
}