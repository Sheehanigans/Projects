using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceShape
{
    class EquilateralTriangle : I2DShape
    {
        public double Area
        {
            get { return (Math.Sqrt(3) / 4) * (Side * Side); }
        }

        public double Parimeter
        {
            get { return Side * 3; }
        }

        public string Name
        {
            get { return "Equilateral Triangle"; }
        }

        public double Side { get; }

        public EquilateralTriangle (double side)
        {
            Side = side;
        }
    }
}
