namespace TicTacToe
{
    public interface IGame
    {
        void StartGame();
        void AddPlayersToGame();
        void SetCurrentPlayer();
        void PlayMove();
        void IsGameOver();
        void GetWinner();
        void EndGame();
    }
}