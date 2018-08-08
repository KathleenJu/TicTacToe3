﻿using System;

namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        public int Id { get; }
        public char Mark { get; private set; }
        
        public ComputerPlayer(int id)
        {
            Id = id;
            SetPlayerMark();
        }

        private void SetPlayerMark()
        {
            var random = new Random();
            var num = random.Next(0, 26); // Zero to 25
            var mark = (char)('a' + num);
            Mark = mark;
        }

        public Coordinates GetPlayerMove()
        {
            var random = new Random();
            var coord = new Coordinates(random.Next(0, 3), random.Next(0, 3), random.Next(0, 3));

            return coord;
        }

        public int GetPlayerId()
        {
            return Id;
        }

        public char GetPlayerMark()
        {
            return Mark;
        }
    }
}