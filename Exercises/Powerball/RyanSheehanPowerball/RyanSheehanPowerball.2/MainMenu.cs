using RyanSheehanPowerball.Workflows;
using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball
{
    class MainMenu
    {
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine();
            Console.WriteLine("1. Enter a Pick");
            Console.WriteLine("2. Show a pick");
            Console.WriteLine("3. Draw!");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine();
            Console.WriteLine("");
            Console.Write("Enter choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "1":
                    AddPickWorkflow addPick = new AddPickWorkflow();
                    addPick.Execute();
                    break;
                case "2":
                    //show pick
                    break;
                case "3":
                    //Draw!
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            return true;
        }

        public static void Show()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }

    }
}
