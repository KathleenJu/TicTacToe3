using System;
using System.Text.RegularExpressions;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class PlayerConsoleRenderer : IPlayerRenderer
    {
        public void RenderMessage(string message)
        {
            Console.Write(message);
        }

        public Coordinates GetCoordinates(int playerId)
        {
            var input = Console.ReadLine();

            const string quitGame = "q";
            if (input == quitGame) throw new QuitGameException("Player " + playerId + " quit the game. End of game.");

            while (!IsInputAValidCoord(input))
            {
                RenderMessage("Wrong coordination format. Try again in x,y,z format e.g. 1,1,2 : ");
                input = Console.ReadLine();
            }

            var row = int.Parse(input.Split(',')[0]) - 1;
            var column = int.Parse(input.Split(',')[1]) - 1;
            var depth = int.Parse(input.Split(',')[2]) - 1;
            return new Coordinates(row, column, depth);
        }

        private static bool IsInputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[0-9],[0-9],[0-9]$");
        }

        public char GetMark()
        {
            var input = Console.ReadLine();
            char mark;
            while (!char.TryParse(input, out mark))
            {
                RenderMessage("Please type in a character for your mark on the board: ");
                input = Console.ReadLine();
            }

            return char.ToUpper(mark);
        }
    }
}