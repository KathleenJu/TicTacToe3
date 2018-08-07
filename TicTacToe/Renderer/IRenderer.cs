namespace TicTacToe
{
    public interface IRenderer
    {
        void DisplayMessage(string message); 
        string GetInput();
    }
}