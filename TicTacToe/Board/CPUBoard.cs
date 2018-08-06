using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace TicTacToe
{
    public class CPUBoard
    {
        public int BoardSizeSize { get; }
        public List<Cell> PlayedCells { get; }
        
        public CPUBoard(List<Cell> playedCells)
        {
            BoardSizeSize = 3;
            PlayedCells = playedCells;
        }

        public CPUBoard(int boardSize, List<Cell> playedCells): this(playedCells)
        {
            BoardSizeSize = boardSize;
        }
    }
}