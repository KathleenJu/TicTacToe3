namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; private set; }
        
        public IPlayerDisplayInterface DisplayInterface;

        public HumanPlayer(int id, IPlayerDisplayInterface displayInterface)
        {
            Id = id;
            DisplayInterface = displayInterface;
        }

        public void SetPlayerMark() // its not returning the playerMark... rename method to setPlayerMark?
        {
            DisplayInterface.DisplayMessage("Player " + Id + " pick your mark on the board e.g. X, O or A: ");
            Mark = DisplayInterface.GetMark();
        }

        public Coordinates GetPlayerMove()
        {
            DisplayInterface.DisplayMessage("Player " + Id + " enter a coord x,y,z to place " + Mark + " or enter 'q' to give up: ");
            var playerMove = DisplayInterface.GetCoordinates(Id);
            return playerMove;
        }
    }
}