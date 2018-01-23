using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        string[,] board = new string[3, 3];
        bool liveGame = true;


        static void Main(string[] args)
        {
            int turns = 0;
            if (turns > 9)
            {
                Console.WriteLine("It's a draw!");
            }
            DrawBoard();
            turns += 1;

            
        }

        static void DrawBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("__|__|__|__");
            Console.WriteLine(" {3} | {4} | {5} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("__|__|__|__");
            Console.WriteLine(" {6} | {7} | {8} ", board[0, 0], board[0, 1], board[0, 2]);
        }
    }
}
