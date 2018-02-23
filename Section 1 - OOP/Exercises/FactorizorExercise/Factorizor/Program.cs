using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {

            Console.WriteLine("Enter a number!");
            string userInput = Console.ReadLine();

            int result;

            if (int.TryParse(userInput, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("NO!");
                return GetNumberFromUser();
            }

            throw new NotImplementedException();
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {

            int perfect = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    perfect += i;
                }
            }
            if (perfect == number)
            {
                Console.WriteLine(number + " is PERFECT");
            }
            else
            {
                Console.WriteLine(number + " is NOT perfect");
            }
        }
        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            bool prime = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    prime = false;                    
                }                
            }
            if (prime == true)
            {
                Console.WriteLine(number + " is PRIME.");
            }
            else
            {
                Console.WriteLine(number + " is NOT prime.");
            }
        }
    }
}


