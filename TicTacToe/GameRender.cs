using System;
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

            var player1 = new HumanPlayer(1, new PlayerConsoleRenderer());
            player1.SetPlayerMark();
            Game.AddPlayerToGame(player1);
            var player2 = new ComputerPlayer(2);
            player2.SetPlayerMark();
            Game.AddPlayerToGame(player2);
            Game.SetCurrentPlayer(player1);

            while (Game.GetGameStatus() != GameStatus.OVER)
            {
                try
                {
                    Game.PlayMove(Game.GetCurrentGamePlayer().GetPlayerMark(), Game.GetCurrentGamePlayer().GetPlayerMove());
                }
                catch (BoardPositionIsOccupiedException ex)
                {
                    Renderer.RenderMessage(ex.Message);
                    break;
                }
                catch (CoordinateIsOutOfBoundsException ex)
                {
                    Renderer.RenderMessage(ex.Message);
                    break;
                }
                catch (QuitGameException ex)
                {
                    Renderer.RenderMessage(ex.Message);
                    return;
                }

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
        }
    }
}