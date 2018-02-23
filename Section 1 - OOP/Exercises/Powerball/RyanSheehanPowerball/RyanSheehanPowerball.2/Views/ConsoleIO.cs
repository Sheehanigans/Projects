using RyanSheehanPowerball._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2.Views
{
    class ConsoleIO
    {
        internal static string GetStringFromUser(string prompt)
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        internal static int[] Draw()
        {
            int[] drawing = new int[5];

            for (int i = 0; i < 5; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    drawing[i] = 0;
                    int num = RNG.NextInt(0, 69);

                    if (drawing.Contains(num))
                    {
                        i--;
                    }
                    else
                    {
                        drawing[i] = num;
                        isValid = true;
                    }
                }
            }

            return drawing;
        }

        internal static int GetIDFromUser(string prompt)
        {
            int output;
            Console.WriteLine(prompt);

            PickRepository repo = new PickRepository(Settings.FilePath);
            List<Pick> picks = repo.List();

            int id = 0;

            bool isValid = false;
            while (!isValid)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("Enter a valid number.");

                }
                else if (output < 0 || output > picks.Count())
                {
                    Console.WriteLine("Pick ID does not exist");
                }
                else
                {
                    id = output;
                    isValid = true;
                }

            }
            return id;
        }

        internal static int[] GetPickNumbers(string prompt)
        {

            Console.Clear(); 

            int output;

            int[] picks = new int[5];
            Console.WriteLine(prompt);

            for (int i = 0; i < 5; i++)
            {
                picks[i] = 0;
                bool isValid = false;

                while (!isValid)
                {
                    Console.WriteLine($"Please enter choice #{i + 1}:");
                    string input = Console.ReadLine();

                    if(!int.TryParse(input, out output))
                    {
                        Console.WriteLine("Enter a valid number.");

                    }
                    else if (output < 0 || output > 69)
                    {
                        Console.WriteLine("Enter a number between 0 and 69");
                    }
                    else if (picks.Contains(output))
                    {
                        Console.WriteLine("You already chose that number!");
                    }
                    else
                    {
                        picks[i] = output;
                        isValid = true;
                    }
                }
            }

            return picks;
        }

        public static int GetPowerball(string prompt)
        {
            int output;
            Console.WriteLine(prompt);

            int pb = 0;

            bool isValid = false;
            while (!isValid)
            {
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("Enter a valid number.");

                }
                else if (output < 0 || output > 26)
                {
                    Console.WriteLine("Enter a number between 0 and 26");
                }
                else
                {
                    pb = output;
                    isValid = true;
                }

            }

            return pb;
        }

        internal static string GetYesOrNo(string prompt)
        {

            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return input;
                }
            }

        }


    }
}
