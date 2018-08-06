using System;
using System.Text.RegularExpressions;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class PlayerConsoleInterface : IPlayerDisplayInterface
    {
        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public string GetInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        public Coordinates GetCoordinates(int playerId)
        {
            var input = GetInput();
            const string quitGame = "q";
            if (input == quitGame) throw new QuitGameException("Player " + playerId + " quit the game. End of game.");
            if (IsInputAValidCoord(input))
            {
                var row = int.Parse(input.Split(',')[0]) - 1;
                var column = int.Parse(input.Split(',')[1]) - 1;
                var depth = int.Parse(input.Split(',')[2]) - 1;
                var playerCoordinates = new Coordinates(row, column, depth);
                return playerCoordinates;
            }

            throw new InvalidCoordinateException("Wrong coordination format. Try again in x,y,z format e.g. 1,1,2 \n");
        }

        private static bool IsInputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[0-9],[0-9],[0-9]$");
        }
        
        public char GetMark()
        {
            var input = GetInput();
            char mark;
            while(!char.TryParse(input, out mark))
            {
                Console.Write("Please type in a character for your mark on the board: ");
                input = GetInput();
            }

            return mark;
        }
    }
}