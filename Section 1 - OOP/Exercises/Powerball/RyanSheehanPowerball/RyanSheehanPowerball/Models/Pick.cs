using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball
{
    public class Pick
    {
        public string PickID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] PickNumbers { get; set; }
        public int Powerball { get; set; }
    }
}
