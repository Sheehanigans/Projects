using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerribleRoommates.DLL.Containers
{
    public class Backpack : Container
    {
        private Item[] items;   
        private int currentIndex = 0;
        private int currentWeight = 0;

        public Backpack(string name, int size, int capacity) 
            : base (name, size, capacity)
        {
            items = new Item[Capacity];
        }

        public bool Add(Item item) // need somewhere to store this
        {
            bool success = false;
            if (item.Size + currentWeight <= Capacity)
            {
                items[currentIndex] = item;
                currentIndex++;
                currentWeight += item.Size;
                success = true;
            }
            return success;
        }
      
    }
}
