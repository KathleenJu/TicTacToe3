using System;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var tictactoeGame = new TicTacToeGame();
            var renderer =  new GameConsoleRenderer();
            var gameRender = new GameRender(tictactoeGame, renderer);
            
            gameRender.PlayGame();
        }
    }
}