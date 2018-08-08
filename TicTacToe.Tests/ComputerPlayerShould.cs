using Moq;
using Xunit;

namespace TicTacToe.Tests
{
    public class ComputerPlayerShould
    {
        [Fact]
        public void ReturnTheComputerPlayerMark()
        {
            var player = new ComputerPlayer(It.IsAny<int>());
            
            Assert.NotNull(player.Mark);
        }
        
       [Fact] 
        public void ReturnTheComputerPlayerMove()
        {
            var player = new ComputerPlayer(It.IsAny<int>());
            var coord = player.GetPlayerMove();
            
            Assert.NotNull(coord);
        }
    }
}