using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BattleShip.UI
{
    static public class Validation
    {
        //public string ValidateCoords(string coords)
        //{
        //    bool validCoords = false;

        //    while (!validCoords)
        //    {
        //        Console.Write("Please enter a coordinate");
        //        string userInput = Console.ReadLine().ToUpper(); //converts to upper case, .ToLower 

        //        if (userInput.Length > 3)
        //        {
        //            Console.WriteLine("Coordinate invalid.");
        //        }
        //        else if (userInput.Length < 2)
        //        {
        //            Console.WriteLine("Coordinate invalid.");
        //        }
        //        else if (string.IsNullOrWhiteSpace(userInput))
        //        {
        //            Console.WriteLine("Coordinate invalid.");
        //        }
        //        else if (!Regex.IsMatch(userInput, @"^[a-zA-Z0-9]+$"))
        //        {
        //            Console.WriteLine("Coordinate invalid.");
        //        }
        //        else
        //        {
        //            validCoords = true;
        //        }
        //    }
        //    return userInput;

        //    throw new NotImplementedException();
        //}
    }
}
