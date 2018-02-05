using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    class RationalNumber : IComparable
    {
        public int Numberator{ get; }
        public int Denominator { get; }

        public RationalNumber (int numerator, int denominator)
        {
            if (denominator <= 0)
            {
                throw new InvalidDenominatorException(denominator);
            }

            Numberator = numerator;
            Denominator = denominator;
        }

        public int CompareTo(object obj)
        {
            RationalNumber that = obj as RationalNumber; //attempt to cast the object into a rational number 

            if ( that == null)
            {
                throw new ArgumentException("Attempted comparison of rational number to something else.", "obj");
            }

            // (a / b) (c / d)

            // a => this.Numerator 
            // b => this.Denominator
            // c => that.Numerator
            // d => that.Denominator

            return (this.Numberator * that.Denominator).CompareTo(that.Numberator + this.Denominator);
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            // x = a / b + c / d

            // a => a.Numerator 
            // b => a.Denominator
            // c => b.Numerator
            // d => b.Denominator

            // bx = a + bc / d
            // bdx = ad + bc
            // x = (ad + bc) / bd 
            // need to reduce

            int newNumerator = (a.Numberator * b.Denominator + a.Denominator * b.Numberator);
            int newDenominator = a.Denominator * b.Denominator;

            int gcd = GreatestCommonDenominator(newNumerator, newDenominator);

            newNumerator /= gcd;
            newDenominator /= gcd;

            return new RationalNumber(newNumerator, newDenominator);

        }

        private static int GreatestCommonDenominator(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        public override string ToString()
        {
            return $"{Numberator} / {Denominator} : {((double)Numberator)/((double)Denominator)}";
        }
    }
}
