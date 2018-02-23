using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshTicTacToe
{
    class Program
    {
        static string[,] board = new string[3, 3];
        static bool GameOver = false;

        static void Main(string[] args)
        {
            bool Player = true;
            int Turn = 1;
            while (!GameOver)
            {
                if (Turn > 9)
                {
                    Console.WriteLine("It's a draw!");
                }
                DrawBoard();
                UserInput(Player);
                Turn += 1;
                WinCheck(board, Player);
                Player = !Player;
            }
            Console.ReadLine();
        }

        static void DrawBoard()
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("-----------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("-----------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", board[0, 0], board[0, 1], board[0, 2]);
        }

        static void UserInput(bool Player)
        {
            string PlayerLetter = "";
            if (Player)
            {
                PlayerLetter = "O";
            }
            else
            {
                PlayerLetter = "X";
            }
            string input = Console.ReadLine();
            bool ValidInput = false;
            do
            {
                switch (input.ToUpper())
                {
                    case "TL":
                        board[2, 0] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "TM":
                        board[2, 1] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "TR":
                        board[2, 2] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "ML":
                        board[1, 0] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "MM":
                        board[1, 1] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "MR":
                        board[1, 2] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "BL":
                        board[0, 0] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "BM":
                        board[0, 1] = PlayerLetter;
                        ValidInput = true;
                        break;
                    case "BR":
                        board[0, 2] = PlayerLetter;
                        ValidInput = true;
                        break;
                    default:
                        Console.WriteLine("Please Insert Valid Input (Ask Ken Emeka or Josh C.");
                        break;
                }
            } while (!ValidInput);
        }
        static void WinCheck(string[,] board, bool Player)
        {
            string winner = "";
            if (Player)
            {
                winner = "Congrats Player 1, you won! Good for you.";
            }
            else
            {
                winner = "Congrats Player 2, you won! Good for you.";
            }

            if (board[2, 0] != null && (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[1, 0] != null && (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[0, 0] != null && (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[2, 0] != null && (board[2, 0] == board[1, 0] && board[1, 0] == board[0, 0]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[2, 1] != null && (board[2, 1] == board[1, 1] && board[1, 1] == board[0, 1]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[2, 2] != null && (board[2, 2] == board[1, 2] && board[1, 2] == board[0, 2]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[2, 0] != null && (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
            else if (board[0, 0] != null && (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]))
            {
                Console.WriteLine(winner);
                GameOver = true;
            }
        }
    }
}
