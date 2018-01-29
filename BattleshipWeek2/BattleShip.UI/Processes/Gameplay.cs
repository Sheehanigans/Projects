using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Gameplay
    {

        public void Play()
        {
            bool stillPlaying = true;

            Console.WriteLine("Hello! Player 1 setup your board. Player 2 will follow. First turn will be randomly chosen.");
            Console.ReadLine();

            Player P1 = Setup.CreatePlayer(1); //one more step to set up board, put that at the top of loop new loop, 
            //Console.Clear();
            Player P2 = Setup.CreatePlayer(2);
            Console.Clear();

            //start here and 
            while (stillPlaying)
            {


                P1.PlayerBoard = Setup.SetUpBoard(P1.Name);
                Console.Clear();

                P2.PlayerBoard = Setup.SetUpBoard(P2.Name);
                Console.Clear();



                //need to start new game from here 

                string firstTurn = Setup.DecideFirstTurn(P1.Name, P2.Name); //return bool, set it to turn 

                bool isP1Turn = true;
                bool gameRunning = true;
                string winner = "";
                string loser = "";

                if (firstTurn == P1.Name)
                {
                    isP1Turn = true;
                }
                else if (firstTurn == P2.Name)
                {
                    isP1Turn = false;
                }
                //gameplay
                while (gameRunning)
                {
                    if (isP1Turn) //could definetly make this one time //if decides who is attacking who 
                    {
                        ConsoleOutput.DrawBoard(P2.PlayerBoard);
                        Console.WriteLine($"{P1.Name} FIRE AWAY!");
                        Coordinate c = ConsoleInput.EnterCoords();
                        FireShotResponse r = P2.PlayerBoard.FireShot(c);
                        Console.Clear();

                        while (r.ShotStatus == ShotStatus.Duplicate || r.ShotStatus == ShotStatus.Invalid) //added invalid
                        {
                            ConsoleOutput.DrawBoard(P2.PlayerBoard);
                            Console.WriteLine("Bad shot! Quit wasting ammo. Try again!");
                            Console.WriteLine($"{P1.Name} FIRE AWAY!");
                            c = ConsoleInput.EnterCoords();
                            r = P2.PlayerBoard.FireShot(c);
                            Console.Clear();
                        }

                        Console.Clear();
                        //draw shot
                        ConsoleOutput.DrawBoard(P2.PlayerBoard);
                        ConsoleOutput.ShotMessage(r, P1.Name, P2.Name);

                        if (r.ShotStatus == ShotStatus.Victory)
                        {
                            winner = P1.Name;
                            loser = P2.Name;
                            gameRunning = false;
                        }
                        isP1Turn = false;

                        Console.Clear();
                    }

                    else if (!isP1Turn)
                    {
                        Console.Clear();
                        ConsoleOutput.DrawBoard(P1.PlayerBoard);
                        Console.WriteLine($"{P2.Name} FIRE AWAY!");
                        Coordinate c = ConsoleInput.EnterCoords();
                        FireShotResponse r = P1.PlayerBoard.FireShot(c);
                        Console.Clear();

                        //invalid shot
                        while (r.ShotStatus == ShotStatus.Duplicate || r.ShotStatus == ShotStatus.Invalid) //added
                        {
                            ConsoleOutput.DrawBoard(P1.PlayerBoard);
                            Console.WriteLine("Bad shot! Quit wasting ammo. Try again!");
                            Console.WriteLine($"{P2.Name} FIRE AWAY!");
                            c = ConsoleInput.EnterCoords();
                            r = P1.PlayerBoard.FireShot(c);
                            Console.Clear();
                        }

                        Console.Clear();
                        //draw shot
                        ConsoleOutput.DrawBoard(P1.PlayerBoard);
                        ConsoleOutput.ShotMessage(r, P1.Name, P2.Name);

                        if (r.ShotStatus == ShotStatus.Victory)
                        {
                            winner = P2.Name;
                            loser = P1.Name;
                            gameRunning = false;
                        }
                        isP1Turn = true;

                        Console.Clear();
                    }
                }
                Console.Clear();
                Console.WriteLine($"The game is over! {winner} is the winner! {loser} loses!");
                stillPlaying = ConsoleInput.PlayAgain();
            }
        }
    }
}
