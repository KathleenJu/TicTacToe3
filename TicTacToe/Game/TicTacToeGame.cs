using System.Collections.Generic;
using TicTacToe.Rules;

namespace TicTacToe
{
    public class TicTacToeGame : IGame
    {
        private readonly ITicTacToeRules _ticTacToeRules;
        private readonly ITicTacToeBoard _ticTacToeBoard;
        private List<IPlayer> _gamePlayers;
        private IPlayer _currentGamePlayer;
        private GameStatus _gameStatus;
         
        public TicTacToeGame()
        {
            _ticTacToeRules = new TicTacToeRules();
            _ticTacToeBoard = new TicTacToeCPUBoard();
        }

        public void StartGame()
        {
            _gameStatus = GameStatus.PLAYING;
        }

        public void AddPlayersToGame()
        {
            throw new System.NotImplementedException();
        }

        public void SetCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void PlayMove(char mark, Coordinates coordinates)
        {
            _ticTacToeBoard.UpdateBoard(mark, coordinates);
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

        public ITicTacToeBoard GetGameBoard()
        {
            return _ticTacToeBoard;
        }
    }
}