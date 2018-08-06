using System;

namespace TicTacToe.Exceptions
{
    public class BoardPositionIsOccupiedException : Exception
    {
        public override string Message { get; }
        
        public BoardPositionIsOccupiedException(string message)
        {
            Message = message;
        } 
    }
}