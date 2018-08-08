namespace TicTacToe
{
    public interface IPlayerRenderer
    {
        void RenderMessage(string message);
        Coordinates GetCoordinates(int playerId);
        char GetMark();
    }
}