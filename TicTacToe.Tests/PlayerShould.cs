using Xunit;

namespace TicTacToe.Tests
{
    public class PlayerShould
    {
        [Fact]
        public void ReturnThePlayerMark()
        {
            var player = new ComputerPlayer();
            var coord = player.GetPlayerMark();
            
            Assert.Equal(coord, 'X');
        }
    }
}