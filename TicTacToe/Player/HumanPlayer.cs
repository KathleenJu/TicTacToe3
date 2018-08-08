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
            SetPlayerMark();
        }

        private void SetPlayerMark() 
        {
            Renderer.RenderMessage("Player " + Id + " pick your mark on the board e.g. X, O or A: ");
            Mark = Renderer.GetMark();
        }

        public Coordinates GetPlayerMove()
        {
            Renderer.RenderMessage("Player " + Id + " enter a coord x,y,z to place " + Mark + " or enter 'q' to give up: ");
            var playerMove = Renderer.GetCoordinates(Id);
            return playerMove;
        }

        public int GetPlayerId()
        {
            return Id;
        }

        public char GetPlayerMark()
        {
            return Mark;
        }
    }
}