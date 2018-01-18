using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            //TODO:  Implement FizzBuzz

            int range = 100;

            for (int i = 1; i <= range; i++)
            {

                bool fizz = i % 3 == 0;
                bool buzz = i % 5 == 0;

                if (fizz && buzz)
                {
                    Console.WriteLine(i + " FizzBuzz");
                }
                else if (buzz)
                {
                    Console.WriteLine(i + " Buzz");
                }
                else if (fizz)
                {
                    Console.WriteLine(i + " Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
