using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.ConsoleUtilities.BLL;

namespace SG.ConsoleUtilities.BLL
{
    public class UserInput
    {
        public static int GetIntFromUSer (string prompt)
        {
            int result;
            string userInput;

            //loop until int is returned 
            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if(int.TryParse(userInput, out result))
                {
                    return result;
                }

                Console.WriteLine("invalid");
            }
        }
    }
}
