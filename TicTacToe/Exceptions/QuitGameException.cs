using System;
using System.Net.Http;

namespace TicTacToe.Exceptions
{
    public class QuitGameException : Exception
    {
        public override string Message { get; }
        
        public QuitGameException(string message)
        {
            Message = message;
        } 
    }
}