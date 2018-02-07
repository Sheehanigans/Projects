using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball
{
    public class Pick
    {
        public int PickID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] PickNumbers { get; set; } = new int[5];
        public int Powerball { get; set; }
    }
}