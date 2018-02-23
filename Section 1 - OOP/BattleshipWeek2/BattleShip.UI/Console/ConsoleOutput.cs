using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public static class ConsoleOutput
    {

        public static void DrawBoard(Board b)
        {
            Console.WriteLine("        1    2    3    4    5    6    7    8    9    10");

            string[,] BoardPrinted = new string[10, 10];
            for (int i = 1; i <= 10; i++)
            {
                char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                Console.Write($" {letters[i - 1]}___|");

                for (int j = 1; j <= 10; j++)
                {
                    Coordinate coord = new Coordinate(i, j);
                    if (b.CheckCoordinate(coord) == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("  M  ");
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    else if (b.CheckCoordinate(coord) == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  H  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.Write("  .  ");
                    }
                }
                Console.WriteLine("");
            }
        }
        public static void ShotMessage(FireShotResponse response, string name1, string name2)
        {
            switch (response.ShotStatus)
            {
                case ShotStatus.Hit:

                    Console.WriteLine("Hit!");
                    Console.ReadLine();
                    break;
                case ShotStatus.Duplicate:
                    Console.WriteLine("Don't waste ammo! You already shot there. Try again.");
                    Console.ReadLine();
                    break;
                case ShotStatus.HitAndSunk:
                    Console.WriteLine($"Hit and sunk!");
                    Console.ReadLine();
                    break;
                case ShotStatus.Invalid:
                    Console.WriteLine("Invalid! Try placing the ship somewhere else");
                    Console.ReadLine();
                    break;
                case ShotStatus.Miss:
                    Console.WriteLine("Miss!");
                    Console.ReadLine();
                    break;
                case ShotStatus.Victory:
                    Console.WriteLine("Victory!");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
