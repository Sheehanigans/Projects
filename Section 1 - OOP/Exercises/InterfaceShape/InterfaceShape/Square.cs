using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceShape
{
    class Square : I2DShape
    {
        public double Area
        {
            get { return Side * Side; }
        }

        public double Parimeter
        {
            get { return Side * 4; }
        }

        public string Name
        {
            get { return "Square"; }
        }

        public double Side { get; }

        public Square (double side)
        {
            Side = side;
        }
    }
}
