using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System.Threading;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    static public class ConsoleInput //static class has static members, we do not need to instantiate a console input class and can call them easier
    {
        //Get names

        public static string PlayerName(int playerNumber)
        {

            string name = "";
            bool isValidName = false;

            if (playerNumber == 1)
            {
                while (!isValidName)
                {
                    Console.Write("Enter Player One's name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Enter a valid name.");
                    }
                    else
                    {
                        isValidName = true;
                    }
                    //Console.Clear();

                }
            }
            else
            {
                while (!isValidName)
                {
                    Console.Write("Enter Player Two's name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Enter a valid name.");
                    }
                    else
                    {
                        isValidName = true;
                    }
                    //Console.Clear();
                }
            }
            return name;
        }

        public static Coordinate EnterCoords()
        {
            Coordinate toReturn;
            bool validCoord = false;

            int coord1 = 0;
            int coord2 = 0;

            if (!validCoord) //do??
            {
                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine("Enter a valid coordinate. A letter A to J and a number 1 to 10. Ex: B4.");
                    string userInput = Console.ReadLine().ToUpper();

                    //check coord 1 and then coord 2
                    //check coord to with tryparse

                    if (userInput.Length > 3 || userInput.Length == 0)
                    {
                        valid = false;
                    }
                    else if (userInput[0] - 'A' + 1 <= 10
                        && Convert.ToInt32(userInput.Substring(1)) > 0
                        && Convert.ToInt32(userInput.Substring(1)) < 11)
                    {
                        coord1 = userInput[0] - 'A' + 1;
                        coord2 = Convert.ToInt32(userInput.Substring(1));
                        valid = true;
                    }
                }
            }
            return toReturn = new Coordinate(coord1, coord2);
        }

        public static ShipDirection EnterDirection()
        {
            ShipDirection toReturn = ShipDirection.Up;

            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("Enter a valid direction. Ex: u for Up, d for Down, l for Left, r for Right.");
                string input = Console.ReadLine().ToLower();
                valid = true;

                switch (input)
                {
                    case "u":
                        toReturn = ShipDirection.Up;
                        break;
                    case "d":
                        toReturn = ShipDirection.Down;
                        break;
                    case "l":
                        toReturn = ShipDirection.Left;
                        break;
                    case "r":
                        toReturn = ShipDirection.Right;
                        break;
                    default:
                        valid = false;
                        break;
                }
            }
            return toReturn;
        }

        public static bool PlayAgain()
        {
            bool playAgain = false;
            string response = "";

            Console.WriteLine("If you'd like to play again, type 'play again'");
            response = Console.ReadLine().ToUpper();


            playAgain = response == "PLAY AGAIN";

            return playAgain;
        }
    }
}
