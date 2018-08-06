namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; }
        
        public IPlayerDisPlayInterface DisplayInterface;

        public HumanPlayer(IPlayerDisPlayInterface displayInterface)
        { 
            DisplayInterface = displayInterface;
        }

        public char GetPlayerMark()
        {
            return 'X';
        }

        public Coordinates MakeAMove()
        {
            throw new System.NotImplementedException();
        }
    }
}