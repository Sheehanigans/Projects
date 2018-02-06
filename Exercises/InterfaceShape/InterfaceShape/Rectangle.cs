using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceShape
{
    class Rectangle : I2DShape
    {
        public double Area
        {
            get { return Length * Width; }
        }

        public double Parimeter
        {
            get { return 2*(Length + Width); }
        }

        public string Name
        {
            get { return "Rectangle"; }
        }

        public double Length { get; }

        public double Width { get; }

        public Rectangle (double length, double width)
        {
            Length = length;
            Width = width;
        }
    }
}
