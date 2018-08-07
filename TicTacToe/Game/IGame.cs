namespace TicTacToe
{
    public interface IGame
    {
        void StartGame();
        void AddPlayersToGame();
        void SetCurrentPlayer();
        void PlayMove(char mark, Coordinates coordinates);
        bool IsGameOver();
        void GetWinner();
        void EndGame();
    }
}