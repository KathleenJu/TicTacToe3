using System;

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
    }
}