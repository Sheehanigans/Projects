using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Garbage
    {
        //get coordinates 
        //    public Coordinate GetCoordinateFromUser()
        //    {
        //        Coordinate toReturn;

        //        Console.WriteLine("Please enter a coordinate");
        //        string userInput = Console.ReadLine().ToUpper(); //converts to upper case, .ToLower 

        //        //validate
        //        //input should be in the form of E7 or e7
        //        //coordinates are 1 to 10, it is NOT an array 0 to 9

        //        //create validation in another function!!! Parse coordinates from the user 

        //        //need to check to make sure the user entered anything at all
        //        //need to only allow letters 
        //        string first = userInput.Substring(0, 1);

        //        string second = userInput.Substring(1);

        //        int firstCoord = first[0] - "A" + 1;

        //        int secondCoord;


        //        // incomplete, keep looping to get the correct input until it's right
        //        if (!int.TryParse(second, out secondCoord))
        //        {
        //            Console.WriteLine("Could not interpret second coord. Retry.");
        //        }

        //        Console.WriteLine("The first coordinate is " + firstCoord);
        //        Console.WriteLine("The second coordinate is " + secondCoord);

        //        //getting char number representations 

        //        for (char c = "a"; c <= "z"; c++)
        //        {
        //            int numberEquivelent = c - "a" + 1;
        //            Console.WriteLine(c + ":" + (int)c + " aka " + numberEquivelent);
        //        }
        //        int number;

        //        int firstCoord =


        //        //prompt user            
        //        throw new NotImplementedException();
        //    }

        //    //loop through ship type enum
        //    //in order to place ships

        //        public void LoopThroughShips()
        //        {
        //            for (ShipType s = ShipType.Destroyer; s <= ShipType.Carrier; s++)
        //            {
        //                ShipType[] allShips = new ShipType[]
        //                {
        //                    ShipType.Battleship,
        //                    //keep adding them by size
        //                }

        //                bool success = PlaceShipRequest(s);
        //                if (!success)
        //                {
        //                    s--; //stay on the same ship if it could not be placed at location 
        //                }
        //            }
        //        }

        //public void Run()
        //{
        //    Player1.PlayerNumber = 1;
        //    Player2.PlayerNumber = 2;

        //    Player1.Name = ConsoleInput.PlayerName(Player1.PlayerNumber);
        //    Player2.Name = ConsoleInput.PlayerName(Player2.PlayerNumber);

        //    Console.Clear();
        //    Console.WriteLine("Hello, " + Player1.Name + " and " + Player2.Name + "! Press any key to begin.");
        //    Console.ReadLine();
        //    Console.Clear();

        //    string firstTurn = DecideFirstTurn(Player1.Name, Player2.Name);

        //    bool player1Ready = false;
        //    bool player2Ready = false;

        //    if (firstTurn == Player1.Name)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(Player1.Name + ", please set your ships. Press any key to begin.");
        //        Console.ReadLine();
        //        SetUpBoard();
        //        player1Ready = true;
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        Console.WriteLine(Player2.Name + ", please set your ships. Press any key to begin.");
        //        Console.ReadLine();
        //        SetUpBoard();
        //        player2Ready = true;
        //    }

        //    while (player1Ready == false)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(Player1.Name + ", please set your ships. Press any key to begin.");
        //        Console.ReadLine();
        //        SetUpBoard();
        //        player1Ready = true;
        //    }
        //    while (player2Ready == false)
        //    {
        //        Console.Clear();
        //        Console.WriteLine(Player2.Name + ", please set your ships. Press any key to begin.");
        //        Console.ReadLine();
        //        SetUpBoard(Player2.PlayerBoard);
        //        player2Ready = true;
        //    }
        //}
        //Player Player2 = new Player();

        //Player1.PlayerNumber = 1;
        //Player2.PlayerNumber = 2;

        //Player1.Name = ConsoleInput.PlayerName(Player1.PlayerNumber);
        //Player2.Name = ConsoleInput.PlayerName(Player2.PlayerNumber);

        //Console.Clear();
        //Console.WriteLine("Hello, " + Player1.Name + " and " + Player2.Name + "! Press any key to begin.");
        //Console.ReadLine();
        //Console.Clear();

        //Console.Clear();
        //Console.WriteLine(Player1.Name + ", please set your ships. Press any key to begin.");
        //Console.ReadLine();
        //SetUpBoard();

        //Console.Clear();
        //Console.WriteLine(Player2.Name + ", please set your ships. Press any key to begin.");
        //Console.ReadLine();
        //SetUpBoard();  

        // inside if for one player turn

        //Console.Clear();
        //ConsoleOutput.DrawBoard(P2.PlayerBoard);
        //Console.WriteLine($"{P1.Name} FIRE AWAY!");
        //Coordinate c = ConsoleInput.EnterCoords();
        //FireShotResponse r = P2.PlayerBoard.FireShot(c);

        //Console.Clear();
        ////draw shot
        //ConsoleOutput.DrawBoard(P2.PlayerBoard);
        //ConsoleOutput.ShotMessage(r, P1.Name, P2.Name);

        //if (r.ShotStatus == ShotStatus.Victory)
        //{
        //    winner = P1.Name;
        //    loser = P2.Name;
        //    gameRunning = false;
        //}
        //turn = false;

        //Console.Clear();

        //invalid shot
    }
}
