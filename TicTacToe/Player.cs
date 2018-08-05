namespace TicTacToe
{
    public class Player
    {
        public int Id { get; }
        public char Mark { get; }
        public IPlayerDisPlayInterface DisplayInterface;

        public Player(int id, char mark, IPlayerDisPlayInterface displayInterface)
        {
            Id = id;
            Mark = mark;
            DisplayInterface = displayInterface;
        }

        public void getMark()
        {
            
        }
    }
}