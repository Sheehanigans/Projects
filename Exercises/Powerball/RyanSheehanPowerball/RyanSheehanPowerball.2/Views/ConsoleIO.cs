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

        internal static int[] GetPickNumbers(string prompt)
        {
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

        internal static int GetPowerball(string prompt)
        {
            Console.WriteLine(prompt);
            int pb = int.Parse(Console.ReadLine());
            return pb;
        }

        internal static object GetYesOrNo(string prompt)
        {
            throw new NotImplementedException();
        }
    }
}
