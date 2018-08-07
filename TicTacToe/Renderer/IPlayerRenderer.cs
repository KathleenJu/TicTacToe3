using System.Reflection;

namespace TicTacToe
{
    public interface IPlayerRenderer : IRenderer
    {
        Coordinates GetCoordinates(int playerId);
        char GetMark();
    }
}