using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerribleRoommates.DLL.Potions;

namespace TerribleRoommates.DLL.Containers
{
    public class FannyPack : Container
    {
        private Item[] potions;
        private int currentIndex = 0;
        private int currentWeight = 0;

        public FannyPack(string name, int size, int capacity)
            : base (name, size, capacity)
        {
            potions = new Item[Capacity];
        }

        public bool Add(Potion potion)
        {
            bool success = false;

            if (potion.Size + currentWeight <= Capacity)
            {
                potions[currentIndex] = potion;
                currentIndex++;
                currentWeight += potion.Size;
                success = true;
            }
            return success;
        }
    }
}
