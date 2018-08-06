namespace TicTacToe
{
    public interface IPlayer
    {
        char GetPlayerMark();
        Coordinates MakeAMove();
    }
}