namespace TicTacToe.Rules
{
    public interface IGameRules
    {
        bool HasWinner(IBoard board);
    }
}