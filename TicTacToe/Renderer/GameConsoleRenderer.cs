using System;
using System.Linq;

namespace TicTacToe
{
    public class GameConsoleRenderer : IRenderer
    {
        public void RenderMessage(string message)
        {
            Console.Write(message);
        }

        public string GetInput()
        {
            var input = Console.ReadLine();
            return input;
        }

//        public int GetBoardSize()
//        {
//            throw new System.NotImplementedException();
//        }

        public void RenderGameBoard(ITicTacToeBoard board)
        {
            for (var depth = 0; depth < board.GetBoardSize(); depth++)
            {
                RenderOneLayerOfBoard(board, depth);
            }
        }

        private static void RenderOneLayerOfBoard(ITicTacToeBoard board, int depth)
        {
            for (var row = 0; row < board.GetBoardSize(); row++)
            {
                for (var col = 0; col < board.GetBoardSize(); col++)
                {
                    var symbolOfCurrentPosition = board.GetPlayedCells()
                        .Where(cell => cell.Coordinates.Row == row && cell.Coordinates.Column == col && cell.Coordinates.Depth == depth)
                        .Select(move => move.State);
                    if (symbolOfCurrentPosition.Any())
                    {
                        Console.Write(" " + symbolOfCurrentPosition.First() + " ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }

        public void RenderWinner(IPlayer winner)
        {
            if (winner != null)
            {
                Console.WriteLine("Move accepted, well done Player " + winner.GetPlayerId() + " you've won the game!");
            }
            else
            {
                Console.WriteLine("Game was a draw!"); //if called earlier in the game, wont say no winner 
            }
        }
    }
}