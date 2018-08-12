﻿using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Rules
{
    public class TicTacToeRules: ITicTacToeRules
    {
        private readonly int NumberOfSymbolsInALineToWin = 3;

        public bool HasWinner(ITicTacToeBoard ticTacToeBoard)
        {
            var lastPlayer = ticTacToeBoard.GetPlayedCells().Last().State;
            var coordinates = ticTacToeBoard.GetPlayedCells().Where(move => move.State == lastPlayer)
                .Select(move => move.Coordinates)
                .ToList();
            var hasWinningLine = new List<bool>
            {
                CheckForWinningRowWithSameDepth(coordinates),
                CheckForWinningRowWithDifferentDepth(coordinates),
                CheckForWinningColumnWithSameDepth(coordinates),
                CheckForWinningColumnWithDifferentDepth(coordinates),
                CheckForWinningDepth(coordinates),
                CheckForWinningVerticalPrimaryDiagonalLine(coordinates),
                CheckForWinningVerticalSecondaryDiagonalLine(coordinates),
                CheckForWinningHorizontalPrimaryDiagonalLine(coordinates),
                CheckForWinningHorizontalSecondaryDiagonalLine(coordinates),
                CheckForWinningVerticalPrimaryDiagonalLineWithDiffentDepth(coordinates),
                CheckForWinningVerticalSecondaryDiagonalLineWithDifferentDepth(coordinates)
            };
            
            return hasWinningLine.Contains(true);
        }

        private bool CheckForWinningRowWithSameDepth(IEnumerable<Coordinates> coordinates)
        {
            var completeRow = coordinates.GroupBy(coord => coord.Row).Where(c => c.Count() == NumberOfSymbolsInALineToWin);
            return completeRow.Any() && coordinates.Where(coord => coord.Row == completeRow.Select(x => x.Key).First()).Select(c => c.Depth).Distinct().Count() == 1;
        }
        
        private bool CheckForWinningRowWithDifferentDepth(IEnumerable<Coordinates> coordinates) //need tests for this
        {
            var completeRow = coordinates.GroupBy(coord => coord.Row).Where(c => c.Count() == NumberOfSymbolsInALineToWin);
            return completeRow.Any() && coordinates.Where(coord => coord.Row == completeRow.Select(x => x.Key).First()).Select(c => c.Depth).Distinct().Count() == NumberOfSymbolsInALineToWin  && coordinates.Where(coord => coord.Row == completeRow.Select(x => x.Key).First()).Select(c => c.Row).Distinct().Count() == NumberOfSymbolsInALineToWin;
        }

        private bool CheckForWinningColumnWithSameDepth(IEnumerable<Coordinates> coordinates)
        {
            var completeColumn = coordinates.GroupBy(coord => coord.Column).Where(c => c.Count() == NumberOfSymbolsInALineToWin);
            return completeColumn.Any() && coordinates.Where(coord => coord.Column == completeColumn.Select(x => x.Key).First()).Select(c => c.Depth).Distinct().Count() == 1;
        }
        private bool CheckForWinningColumnWithDifferentDepth(IEnumerable<Coordinates> coordinates)
        {
            var completeColumn = coordinates.GroupBy(coord => coord.Column).Where(c => c.Count() == NumberOfSymbolsInALineToWin);
            return completeColumn.Any() && coordinates.Where(coord => coord.Column == completeColumn.Select(x => x.Key).First()).Select(c => c.Depth).Distinct().Count() == NumberOfSymbolsInALineToWin  && coordinates.Where(coord => coord.Column == completeColumn.Select(x => x.Key).First()).Select(c => c.Row).Distinct().Count() == NumberOfSymbolsInALineToWin;
        }
        
        private bool CheckForWinningDepth(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.GroupBy(coord => coord.Row).Select(columns => columns.Count()).Any(count => count == NumberOfSymbolsInALineToWin) && coordinates.GroupBy(coord => coord.Column).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
        }
        
        private bool CheckForWinningVerticalPrimaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Row == coord.Column).Distinct().Count() == NumberOfSymbolsInALineToWin && coordinates.GroupBy(coord => coord.Depth).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }

        private bool CheckForWinningVerticalSecondaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Row + coord.Column == NumberOfSymbolsInALineToWin - 1).Distinct().Count() == NumberOfSymbolsInALineToWin  && coordinates.GroupBy(coord => coord.Depth).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }
        
        //row with different depth??
        private bool CheckForWinningHorizontalPrimaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Depth + coord.Column == NumberOfSymbolsInALineToWin - 1).Distinct().Count() == NumberOfSymbolsInALineToWin && coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }

        private bool CheckForWinningHorizontalSecondaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.Where(coord => coord.Depth == coord.Column).Distinct().Count() == NumberOfSymbolsInALineToWin && coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }
        
        private bool CheckForWinningVerticalPrimaryDiagonalLineWithDiffentDepth(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Row == coord.Column && coord.Column == coord.Depth).Distinct().Count() == NumberOfSymbolsInALineToWin;
        }

        private bool CheckForWinningVerticalSecondaryDiagonalLineWithDifferentDepth(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Row + coord.Column == NumberOfSymbolsInALineToWin - 1).Distinct().Count() == NumberOfSymbolsInALineToWin  && coordinates.GroupBy(coord => coord.Depth).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }
    }
}