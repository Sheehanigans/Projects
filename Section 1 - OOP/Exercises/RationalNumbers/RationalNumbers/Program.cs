using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RationalNumber> allNumbers = new List<RationalNumber>();

            allNumbers.Add(new RationalNumber(7, 5));
            allNumbers.Add(new RationalNumber(1, 4));
            allNumbers.Add(new RationalNumber(2, 7));
            allNumbers.Add(new RationalNumber(3, 5));

            allNumbers.Sort();

            RationalNumber sum = new RationalNumber(0, 1);

            foreach ( var number in allNumbers)
            {
                sum += number;
                Console.WriteLine(number);
            }

            Console.WriteLine("Sum = " + sum);

            Console.ReadLine();

        }
    }
}
