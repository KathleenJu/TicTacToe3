using System.Collections.Generic;
using System.Linq;
using TicTacToe.Rules;

namespace TicTacToe
{
    public class TicTacToeGame : IGame
    {
        private readonly ITicTacToeRules _ticTacToeRules;
        private readonly ITicTacToeBoard _ticTacToeBoard;
        private readonly List<IPlayer> _gamePlayers;
        private IPlayer _currentGamePlayer;
        private GameStatus _gameStatus;

        public TicTacToeGame()
        {
            _ticTacToeRules = new TicTacToeRules();
            _ticTacToeBoard = new TicTacToeCPUBoard();
            _gamePlayers = new List<IPlayer>();
        }

        public void StartGame()
        {
            _gameStatus = GameStatus.PLAYING;
        }

        public void AddPlayerToGame(IPlayer player)
        {
            if (!_gamePlayers.Any(gamePlayer => gamePlayer.GetPlayerMark() == player.GetPlayerMark()))
            {
                _gamePlayers.Add(player);
            }
            else
            {
                throw new System.Exception("Mark is already taken by another player. \n");
            }
        }

        public void SetCurrentPlayer(IPlayer player)
        {
            _currentGamePlayer = player;
        }

        public void PlayMove(char mark, Coordinates coordinates)
        {
            _ticTacToeBoard.UpdateBoard(mark, coordinates);
        }

        public bool IsGameOver()
        {
            return _ticTacToeRules.HasWinner(_ticTacToeBoard) || IsDrawGame();
        }

        private bool IsDrawGame()
        {
            return _ticTacToeBoard.GetPlayedCells().Count == _ticTacToeBoard.GetBoardSize() * _ticTacToeBoard.GetBoardSize() *  _ticTacToeBoard.GetBoardSize();
        }

        public IPlayer GetWinner()
        {
            return _ticTacToeRules.HasWinner(_ticTacToeBoard)? _gamePlayers.First(gamePlayer => gamePlayer.GetPlayerMark() == _ticTacToeBoard.GetPlayedCells().Last().State) : null;
        }

        public void EndGame()
        {
            _gameStatus = GameStatus.OVER;
        }

        public ITicTacToeBoard GetGameBoard()
        {
            return _ticTacToeBoard;
        }

        public List<IPlayer> GetGamePlayers()
        {
            return _gamePlayers;
        }

        public IPlayer GetCurrentGamePlayer()
        {
            return _currentGamePlayer;
        }

        public GameStatus GetGameStatus()
        {
            return _gameStatus;
        }
    }
}