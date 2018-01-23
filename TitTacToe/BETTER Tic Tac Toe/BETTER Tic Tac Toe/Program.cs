using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETTER_Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize gameboard 
            BoardPosition[,] gameBoard = InitializeBoard();

            //decide who goes first
            bool isXTurn = true;

            //take turns until (while) game is over
            bool isGameOver = false;
            while (!isGameOver)
            {
                MakeMove(gameBoard, isXTurn);
                isGameOver = CheckForEndGame(gameBoard);
                isXTurn = !isXTurn;
            }
        }

        private static bool CheckForEndGame(BoardPosition[,] gameBoard)
        {
            //throw new NotImplementedException();
            return false;
        }

        private static BoardPosition[,] InitializeBoard()
        {
            BoardPosition[,] gameBoard = new BoardPosition[3, 3];
            for ( int row = 0; row < 3; row++)
            {
                for ( int col = 0; col < 3; col++)
                {
                    gameBoard[row, col] = BoardPosition.Blank;
                }
            }
            return gameBoard;
        }

        private static void MakeMove(BoardPosition[,] gameBoard, bool isXTurn)
        {
            //display board
            DisplayBoard(gameBoard);

            bool hasValidInput = false;
            while (!hasValidInput)
            {
                //get input from the user
                string userAttempt = Console.ReadLine();
                //determine if valid


                //789 678   (0,2)(1,2)(2,2)
                //456 345   (0,1)(1,1)(2,1)
                //123 012   (0,0)(1,0)(2,0)

                int attemptNumber = int.MinValue;

                if (int.TryParse(userAttempt, out attemptNumber))
                {
                    // we knoew they entered a number 
                    if (attemptNumber > 0 && attemptNumber < 10)
                    {

                        attemptNumber--;
                        // we know they entered a number on the board 
                        int row = attemptNumber / 3;
                        int col = attemptNumber % 3;

                        hasValidInput = gameBoard[row, col] == BoardPosition.Blank; //returns true if these are the same 

                        gameBoard[row, col] = isXTurn ? BoardPosition.X : BoardPosition.O;

                        //This is the long version of ^^
                        //if (isXTurn)
                        //{
                        //    gameBoard[row, col] = BoardPosition.X;
                        //}
                        //else
                        //{
                        //    gameBoard[row, col] = BoardPosition.O;
                        //}


                    }
                }
                //update game state


            }

        }

        private static void DisplayBoard(BoardPosition[,] gameBoard)
        {

            //work backwards through row 
            for (int row = 2; row>=0; row--)
            {
                //work forward through cols 
                for (int col = 0; col < 3; col++)
                {
                    switch (gameBoard[row, col])
                    {
                        case BoardPosition.Blank:
                            Console.WriteLine(" |");
                            break;
                        case BoardPosition.O:
                            Console.WriteLine(" O|");
                            break;
                        case BoardPosition.X:
                            Console.WriteLine(" X|");
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("---------");
                }

            }
        }
    }
}
