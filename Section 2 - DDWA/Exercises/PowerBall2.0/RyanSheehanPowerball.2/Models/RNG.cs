using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2.Models
{
    public static class RNG
    {
        static Random _generator = new Random();

        public static int NextInt (int incMin, int excMax)
        {
            return _generator.Next(incMin, excMax);
        }
    }
}
