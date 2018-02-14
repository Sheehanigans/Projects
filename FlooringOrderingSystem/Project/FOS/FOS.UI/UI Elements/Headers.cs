using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.UI.UI_Elements
{
    public class Headers
    {
        public static string SeperatorBar = "=================================";

        public static void AddOrderHeader()
        {
            Console.WriteLine();
            Console.WriteLine(SeperatorBar);
            Console.WriteLine("         Add An Order:       ");
            Console.WriteLine(SeperatorBar);
            Console.WriteLine();
        }

        public static void DisplayOrderHeader()
        {
            Console.WriteLine();
            Console.WriteLine(SeperatorBar);
            Console.WriteLine("         Display an Order       ");
            Console.WriteLine(SeperatorBar);
            Console.WriteLine();
        }
    }
}
