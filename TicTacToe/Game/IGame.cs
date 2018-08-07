namespace TicTacToe
{
    public interface IGame
    {
        void StartGame();
        void AddPlayersToGame(IPlayer player);
        void SetCurrentPlayer(IPlayer player);
        void PlayMove(char mark, Coordinates coordinates);
        bool IsGameOver();
        IPlayer GetWinner();
        void EndGame();
    }
}