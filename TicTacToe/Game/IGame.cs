namespace TicTacToe
{
    public interface IGame
    {
        void StartGame();
        void AddPlayersToGame();
        void SetCurrentPlayer();
        void PlayMove(char mark, Coordinates coordinates);
        void IsGameOver();
        void GetWinner();
        void EndGame();
    }
}