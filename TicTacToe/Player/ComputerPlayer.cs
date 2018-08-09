using System;

namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; private set; }
        private readonly IPlayerRenderer Renderer;
        
        public ComputerPlayer(int id, IPlayerRenderer renderer)
        {
            Id = id;
            Renderer = renderer;
            SetPlayerMark();
        }

        private void SetPlayerMark()
        {
            Renderer.RenderMessage("Pick a mark for computer player " + Id + ": ");
            Mark = Renderer.GetMark();
        }

        public Coordinates GetPlayerMove()
        {
            var random = new Random();
            var coord = new Coordinates(random.Next(0, 3), random.Next(0, 3), random.Next(0, 3));

            return coord;
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