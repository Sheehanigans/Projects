using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerribleRoommates.DLL.Potions
{
    abstract public class Potion : Item
    {
        public int Effect { get; set; }

        public Potion(string name, int size, int effect)
            : base(name, size, ItemType.Potion)
        {
            Effect = effect;
        }
    }
}
