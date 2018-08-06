using System.Reflection;

namespace TicTacToe
{
    public interface IPlayerDisplayInterface : IDisplayInterface
    {
        Coordinates GetCoordinates(int playerId);
        char GetMark();
    }
}