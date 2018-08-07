namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; private set; }
        public IPlayerRenderer Renderer;

        public HumanPlayer(int id, IPlayerRenderer renderer)
        {
            Id = id;
            Renderer = renderer;
        }

        public void SetPlayerMark() 
        {
            Renderer.DisplayMessage("Player " + Id + " pick your mark on the board e.g. X, O or A: ");
            Mark = Renderer.GetMark();
        }

        public Coordinates GetPlayerMove()
        {
            Renderer.DisplayMessage("Player " + Id + " enter a coord x,y,z to place " + Mark + " or enter 'q' to give up: ");
            var playerMove = Renderer.GetCoordinates(Id);
            return playerMove;
        }
    }
}