using System.Collections.Generic;
using TicTacToe.Rules;

namespace TicTacToe
{
    public class TicTacToeGame : IGame
    {
        private readonly IGameRules GameRules;
        private readonly IBoard GameBoard;
        private readonly List<IPlayer> GamePlayers;
        private readonly IPlayer CurrentGamePlayer;
        private readonly GameStatus GameStatus;
         
        public TicTacToeGame()
        {
           
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public void AddPlayersToGame()
        {
            throw new System.NotImplementedException();
        }

        public void SetCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void PlayMove()
        {
            throw new System.NotImplementedException();
        }

        public void IsGameOver()
        {
            throw new System.NotImplementedException();
        }

        public void GetWinner()
        {
            throw new System.NotImplementedException();
        }

        public void EndGame()
        {
            throw new System.NotImplementedException();
        }
    }
}