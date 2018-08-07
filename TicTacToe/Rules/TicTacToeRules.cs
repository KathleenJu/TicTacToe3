using System.Collections.Generic;
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
                CheckForWinningRow(coordinates),
                CheckForWinningColumn(coordinates),
                CheckForWinningDepth(coordinates),
                CheckForWinningVerticalPrimaryDiagonalLine(coordinates),
                CheckForWinningVerticalSecondaryDiagonalLine(coordinates),
                CheckForWinningHorizontalPrimaryDiagonalLine(coordinates),
                CheckForWinningHorizontalSecondaryDiagonalLine(coordinates)
            };
            
            return hasWinningLine.Contains(true);
        }

        private bool CheckForWinningRow(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) && coordinates.GroupBy(coord => coord.Depth).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
        }

        private bool CheckForWinningColumn(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.GroupBy(coord => coord.Column).Select(columns => columns.Count()).Any(count => count == NumberOfSymbolsInALineToWin) && coordinates.GroupBy(coord => coord.Depth).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin);
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
        
        private bool CheckForWinningHorizontalPrimaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return coordinates.Where(coord => coord.Depth + coord.Column == NumberOfSymbolsInALineToWin - 1).Distinct().Count() == NumberOfSymbolsInALineToWin && coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }

        private bool CheckForWinningHorizontalSecondaryDiagonalLine(IEnumerable<Coordinates> coordinates)
        {
            return  coordinates.Where(coord => coord.Depth == coord.Column).Distinct().Count() == NumberOfSymbolsInALineToWin && coordinates.GroupBy(coord => coord.Row).Select(rows => rows.Count()).Any(count => count == NumberOfSymbolsInALineToWin) ;
        }
    }
}