using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funtimez
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "corndog";

            string[] output = StringByTwo(input);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
            Console.ReadLine();
        }

        static public string[] StringByTwo(string input)
        {
            string[] twos;

            int half = input.Length / 2;
            int even = input.Length % 2;
            twos = new string[even + half];            

            int arrayPos = 0;

            for (int i = 0; i < input.Length - 1; i += 2)
            {
                twos[arrayPos] += input.Substring(i, 2);
                arrayPos++;
            }
            if (even == 1)
            {
                twos[arrayPos] = input.Substring(input.Length - 1);
            }
            return twos;              
            }
        }

    }
