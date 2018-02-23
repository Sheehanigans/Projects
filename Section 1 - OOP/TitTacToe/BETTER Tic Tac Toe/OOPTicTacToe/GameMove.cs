using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTicTacToe
{
    class GameMove
    {
        public bool IsXTurn { get; }
        public int Row { get; }
        public int Col { get; }

        public GameMove(int row, int col, bool isXTurn)
        {
            IsXTurn = isXTurn;
            Row = row;
            Col = col;
        }
    }
}
