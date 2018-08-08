namespace TicTacToe
{
    public interface IRenderer
    {
        void RenderMessage(string message); 
        string GetInput();
        void RenderGameBoard(ITicTacToeBoard board);
        void RenderWinner(IPlayer winner);
    }
}