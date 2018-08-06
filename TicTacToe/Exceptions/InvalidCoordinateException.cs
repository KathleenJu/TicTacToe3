using System;

namespace TicTacToe.Exceptions
{
    public class InvalidCoordinateException : Exception
    {
        public override string Message { get; }
        
        public InvalidCoordinateException(string message)
        {
            Message = message;
        } 
    }
}