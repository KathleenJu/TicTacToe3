﻿using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class TicTacToeCPUBoard : ITicTacToeBoard
    {
        private readonly int _boardSize;
        private readonly List<Cell> _playedCells;

        public TicTacToeCPUBoard()
        {
            _boardSize = 3;
            _playedCells = new List<Cell>();
        }

        public TicTacToeCPUBoard(int boardSize) : this()
        {
            _boardSize = boardSize;
        }

        public void UpdateBoard(char mark, Coordinates playerCoordinates)
        {
            if (!IsEmptyPosition(playerCoordinates))
            {
                var markInOccupiedPosition = _playedCells.Where(c =>
                    c.Coordinates.Row == playerCoordinates.Row && c.Coordinates.Column == playerCoordinates.Column &&
                    c.Coordinates.Depth == playerCoordinates.Depth).Select(x => x.State).First();
                throw new BoardPositionIsOccupiedException("Position is already occupied by " +  markInOccupiedPosition + ".\n");
            }

            if (!IsValidCoordinate(playerCoordinates))
            {
                throw new CoordinateIsOutOfBoundsException("Coordinate is out of bounds. \n");
            }

            var cell = new Cell(mark, playerCoordinates);
            _playedCells.Add(cell);
        }

        public bool IsEmptyPosition(Coordinates playerCoordinates)
        {
            return !_playedCells.Any(cell =>
                cell.Coordinates.Row == playerCoordinates.Row && cell.Coordinates.Column == playerCoordinates.Column &&
                cell.Coordinates.Depth == playerCoordinates.Depth);
        }

        public bool IsValidCoordinate(Coordinates coordinates)
        {
            return coordinates.Row < _boardSize && coordinates.Row >= 0 && coordinates.Column < _boardSize &&
                   coordinates.Column >= 0;
        }

        public int GetBoardSize()
        {
            return _boardSize;
        }

        public List<Cell> GetPlayedCells()
        {
            return _playedCells;
        }
    }
}