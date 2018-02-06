using System;
using System.Collections.Generic;

namespace InterfaceShape
{
    class Program
    {
        static void Main(string[] args)
        {
            List<I2DShape> shapes = new List<I2DShape>();

            shapes.Add(new Circle(3));
            shapes.Add(new Rectangle(3, 4));
            shapes.Add(new Square(4));
            shapes.Add(new EquilateralTriangle(5));

            foreach (I2DShape shape in shapes)
            {
                PrintInfo(shape);
            }
            Console.ReadLine();


        }
        public static void PrintInfo(I2DShape shape)
        {
            Console.WriteLine($"Name: {shape.Name}");
            Console.WriteLine($"Area: {shape.Area}");
            Console.WriteLine($"Perimeter: {shape.Parimeter}");
        }
        public static I2DShape GreaterArea(I2DShape shape1, I2DShape shape2)
        {
            if (shape1.Area > shape2.Area)
            {
                Console.WriteLine($"{shape1.Name}'s area: {shape1.Area} is greater than {shape2.Name}'s area: {shape2.Area}.");
                return shape1;
            }
            else
            {
                Console.WriteLine($"{shape2.Name}'s area: {shape2.Area} is greater than {shape1.Name}'s area: {shape1.Area}.");
                return shape2;
            }
        }
    }
}

