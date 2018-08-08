using System;
using System.Globalization;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class GameRender
    {
        private readonly IGame Game;
        private readonly IRenderer Renderer;

        public GameRender(IGame game, IRenderer renderer)
        {
            Game = game;
            Renderer = renderer;
        }

        public void PlayGame()
        {
            Game.StartGame();
            Renderer.RenderMessage("Welcome to 3D Tic Tac Toe! \n");
            Renderer.RenderMessage("Here's the current board: \n");
            Renderer.RenderGameBoard(Game.GetGameBoard());

            SetPlayers();

            while (Game.GetGameStatus() != GameStatus.OVER)
            {
                try
                {
                    var playerMove = Game.GetCurrentGamePlayer().GetPlayerMove();
                    Game.PlayMove(Game.GetCurrentGamePlayer().GetPlayerMark(), playerMove);

                    Renderer.RenderMessage("Move accepted, here's the current board: \n");
                    Renderer.RenderGameBoard(Game.GetGameBoard());
                    if (Game.IsGameOver())
                    {
                        Game.EndGame();
                        Renderer.RenderWinner(Game.GetWinner());
                    }

                    var newCurrentPlayer = Game.GetGamePlayers().Where(player => player != Game.GetCurrentGamePlayer())
                        .Select(player => player).First();
                    Game.SetCurrentPlayer(newCurrentPlayer);
                }
                catch (BoardPositionIsOccupiedException ex)
                {
                    Renderer.RenderMessage(ex.Message);
                }
                catch (CoordinateIsOutOfBoundsException ex)
                {
                    Renderer.RenderMessage(ex.Message);
                }
                catch (QuitGameException ex)
                {
                    Renderer.RenderMessage(ex.Message);
                    return;
                }
            }
        }

        private void SetPlayers()
        {
            var numberOfHumanPlayers = GetNumberOfPlayers("human");
            var numberOfComputerPlayers = GetNumberOfPlayers("computer");
            if (numberOfHumanPlayers != 0)
            {
                for (var i = 1; i <= numberOfHumanPlayers; i++)
                {
                    var humanPlayer = new HumanPlayer(i, new PlayerConsoleRenderer());
                    Game.AddPlayerToGame(humanPlayer);
                    
                }
            }
            if (numberOfComputerPlayers != 0)
            {
                for (var i = 1; i <= numberOfComputerPlayers + 1; i++)
                {
                    var computerPlayer = new ComputerPlayer(i);
                    Game.AddPlayerToGame(computerPlayer);
                }
            }
            Game.SetCurrentPlayer(Game.GetGamePlayers().First());
        }

        public int GetNumberOfPlayers(string typeOfPlayer)
        {
            Renderer.RenderMessage("Please type in the number of " + typeOfPlayer + " players: ");
            var input = Renderer.GetInput();
            int numberOfPlayer;
            while (!int.TryParse(input, out numberOfPlayer))
            {
                Renderer.RenderMessage("Invalid number. Please type in a number: ");
                input = Console.ReadLine();
            }

            return numberOfPlayer;
        }
    }
}