namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; private set; }
        
        public IPlayerDisplayInterface DisplayInterface;

        public HumanPlayer(IPlayerDisplayInterface displayInterface)
        { 
            DisplayInterface = displayInterface;
        }

        public void GetPlayerMark()
        {
            DisplayInterface.DisplayMessage("Player " + Id + " pick your mark on the board e.g. X, O or A: ");
            DisplayInterface.GetInput();
//            Mark = 'X';
        }

        public Coordinates GetPlayerMove()
        {
            DisplayInterface.DisplayMessage("Player " + Id + "enter a coord x,y,z to place " + Mark + " or enter 'q' to give up: ");
            DisplayInterface.GetInput();
        }
    }
}