using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTicTacToe
{
    class Board
    {
        BoardPosition[,] _gameState = new BoardPosition[3, 3];

        public Board()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _gameState[row, col] = BoardPosition.Blank;
                }

                public Board MakeMove
            }
        }
    }
}
