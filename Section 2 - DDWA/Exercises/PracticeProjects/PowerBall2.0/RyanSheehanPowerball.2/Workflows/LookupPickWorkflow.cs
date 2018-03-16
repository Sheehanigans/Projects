using RyanSheehanPowerball._2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2.Workflows
{
    public class LookupPickWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Lookup a pick.");
            Console.WriteLine();

            PickRepository repo = new PickRepository(Settings.FilePath);
            List<Pick> picks = repo.List();

            int index = ConsoleIO.GetIDFromUser("What is your Pick ID?");

            foreach (var pick in picks)
            {
                if (pick.PickID == index)
                {
                    Console.WriteLine($"Pick ID: {pick.PickID}");
                    Console.WriteLine($"Name: {pick.FirstName} {pick.LastName}");
                    Console.WriteLine($"Numbers: {pick.PickNumbers[0]},{pick.PickNumbers[1]}," +
                        $"{pick.PickNumbers[2]},{pick.PickNumbers[3]},{pick.PickNumbers[4]},");
                    Console.WriteLine($"Powerball: {pick.Powerball}");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
