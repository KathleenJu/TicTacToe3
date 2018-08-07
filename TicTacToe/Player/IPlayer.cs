namespace TicTacToe
{
    public interface IPlayer
    {
        void SetPlayerMark();
        Coordinates GetPlayerMove();
        int GetPlayerId();
        char GetPlayerMark();
    }
}