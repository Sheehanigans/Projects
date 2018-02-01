using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Helpers
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "==============================================";

        public const string StudentLineFormat = "{0, -20} {1, -15} {2, 5}";

        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Must enter valid text");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        internal static decimal GetRequiredDecimalFromUser(string prompt)
        {
            decimal output; 

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("Must enter valid decimal");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 0 || output > 4)
                    {
                        Console.WriteLine("GPA must be between 0 and 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue; //goes to the top of the loop
                    }
                    return output;
                }
            }
        }

        public static void PrintstudentListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(StudentLineFormat, "Name", "Major", "GPA");
            Console.WriteLine(SeparatorBar);
        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Must enter Y/N text");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("Must enter Y/N text");
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
