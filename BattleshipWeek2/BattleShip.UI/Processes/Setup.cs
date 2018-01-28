using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public static class Setup
    {
        //Set Up Board 
        //Place ships 

        //loop trough each ship type 
        //- get coords 
        //- get direction
        //- attempt placement 
        //- back up if failure

        //after setup set up game workflow 
        //pass in setup object to gameflow 


        public static Player CreatePlayer(int playerNumber)
        {
            Player player = new Player(ConsoleInput.PlayerName(playerNumber));
            //Board board = new Board();
            //player.PlayerBoard = SetUpBoard(player.Name);

            return player;
        }

        //public static Player PlayAgain(string name)
        //{
        //    Player player = new Player(name);
        //    player.PlayerBoard = SetUpBoard(player.Name);

        //    return player;
        //}

        public static Board SetUpBoard(string name)
        {
            Console.WriteLine($"{name}, set up your ships.");
            Board board = new Board();
            ConsoleOutput.DrawBoard(board);
            for (ShipType s = ShipType.Destroyer; s <= ShipType.Carrier; s++)
            {
                Console.WriteLine("Place your " + s);
                PlaceShipRequest request = new PlaceShipRequest();
                request.ShipType = s;
                request.Coordinate = ConsoleInput.EnterCoords();
                request.Direction = ConsoleInput.EnterDirection();

                ShipPlacement result = board.PlaceShip(request);

                if (result != ShipPlacement.Ok)
                {
                    Console.WriteLine("Invalid location, try again.");
                    s--; //could do error too
                }                             

            }
            Console.WriteLine("You are finished.");
            Console.ReadLine();
            return board;
        }

        public static Random pick = new Random();

        public static string DecideFirstTurn(string player1, string player2)
        {
            int roll = pick.Next(2);
            string firstTurn = "";

            if (roll == 1)
            {
                firstTurn = player1;
            }
            else
            {
                firstTurn = player2;
            }
            Console.WriteLine($"{firstTurn} goes first! Press any key to begin.");
            Console.ReadLine();
            return firstTurn;
        }
    }
}
