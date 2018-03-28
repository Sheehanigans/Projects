using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var ll = new SinglyLinkedList<int>();

            Print(ll);

            for (int i = 0; i < 25; i++)
            {
                ll.Add(i);
            }

            ll.RemoveAt(7);


            Print(ll);

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static void Print<T> (SinglyLinkedList<T> list)
        {
            Console.WriteLine("List contents");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
