using RyanSheehanPowerball._2.Data;
using RyanSheehanPowerball._2.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball.Workflows
{
    public class AddPickWorkflow
    {
        //private IPickRepository _creator;

        //public AddPickWorkflow(IPickRepository concrete)
        //{
        //    _creator = concrete;
        //}

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add your picks!");
            Console.WriteLine();

            Pick pick = new Pick();

            pick.PickID = PickID.GetPickID();
            pick.FirstName = ConsoleIO.GetStringFromUser("Enter your first name: ");
            pick.LastName = ConsoleIO.GetStringFromUser("Enter your last name: ");
            pick.PickNumbers = ConsoleIO.GetPickNumbers("Choose your 5 numbers: ");
            pick.Powerball = ConsoleIO.GetPowerball("Choose your POWERBALL: ");

            Console.WriteLine();
            Console.WriteLine($"Pick ID: {pick.PickID}. {pick.FirstName} {pick.LastName}, you chose " +
                $"{pick.PickNumbers[0]},{pick.PickNumbers[1]},{pick.PickNumbers[2]},{pick.PickNumbers[3]}," +
                $"{pick.PickNumbers[4]} with a POWERBALL of {pick.Powerball}");
            Console.WriteLine();

            if (ConsoleIO.GetYesOrNo("Add the following information?") == "Y")
            {
                PickRepository repo = new PickRepository(Settings.FilePath);
                repo.Add(pick);
                Console.WriteLine("Your pick has been added!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Pick cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }

    }
}
