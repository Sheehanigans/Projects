using RyanSheehanPowerball._2.Data;
using RyanSheehanPowerball._2.Models;
using RyanSheehanPowerball._2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2.Workflows
{
    public class DrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Time to draw!");
            Console.WriteLine("\nPress any key to draw!");
            Console.ReadKey();

            int[] draw = new int[5];

            draw = ConsoleIO.Draw();

            int powerball = RNG.NextInt(0, 26);

            Console.WriteLine($"Winning numbers are: {draw[0]}, {draw[1]}, {draw[2]}, {draw[3]}, {draw[4]}");
            Console.WriteLine($"The Powerball! is {powerball}");
            Console.WriteLine("\nThanks for playing! Press any key to continue...");
            Console.ReadKey();
        }
    }
}
