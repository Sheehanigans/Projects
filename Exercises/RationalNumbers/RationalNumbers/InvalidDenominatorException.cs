using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    class InvalidDenominatorException : Exception
    {
        public int AttemptedDenominator { get; }

        public InvalidDenominatorException( int attemptedDenominator)
        {
            AttemptedDenominator = attemptedDenominator;
        }
    }
}
