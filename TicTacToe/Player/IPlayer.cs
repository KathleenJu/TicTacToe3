namespace TicTacToe
{
    public interface IPlayer
    {
        void SetPlayerMark();
        Coordinates GetPlayerMove();
    }
}