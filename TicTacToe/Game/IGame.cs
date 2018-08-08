using System.Collections.Generic;

namespace TicTacToe
{
    public interface IGame
    {
        void StartGame();
        void AddPlayerToGame(IPlayer player);
        void SetCurrentPlayer(IPlayer player);
        void PlayMove(char mark, Coordinates coordinates);
        bool IsGameOver();
        IPlayer GetWinner();
        void EndGame();
        ITicTacToeBoard GetGameBoard();
        List<IPlayer> GetGamePlayers();
        IPlayer GetCurrentGamePlayer();
        GameStatus GetGameStatus();
    }
}