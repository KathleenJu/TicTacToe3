namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; }
        
        public char GetPlayerMark()
        {
            throw new System.NotImplementedException();
        }

        public Coordinates MakeAMove()
        {
            throw new System.NotImplementedException();
        }
    }
}