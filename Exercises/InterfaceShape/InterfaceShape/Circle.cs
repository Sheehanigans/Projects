using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceShape
{
    class Circle : I2DShape
    {

        double pi = Math.PI;

        public double Area
        {
            get { return R * R * pi; }
        }

        public double Parimeter
        {
            get { return 2 * pi * R; }
        }

        public string Name
        {
            get { return "Circle"; }
        }

        public double R { get; }


        public Circle (double r)
        {
            R = r;
        }
    }
}
