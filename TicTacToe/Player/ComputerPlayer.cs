﻿using System;

namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; private set; }
        
        public void GetPlayerMark()
        {
            var random = new Random();
            int num = random.Next(0, 26); // Zero to 25
            char mark = (char)('a' + num);
            Mark = mark;
        }

        public Coordinates GetPlayerMove()
        {
            throw new System.NotImplementedException();
        }
    }
}