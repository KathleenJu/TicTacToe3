using System;

namespace TicTacToe.Exceptions
{
    public class CoordinateIsOutOfBoundsException : Exception
    {
        public override string Message { get; }

        public CoordinateIsOutOfBoundsException(string message)
        {
            Message = message;
        }
    }
}