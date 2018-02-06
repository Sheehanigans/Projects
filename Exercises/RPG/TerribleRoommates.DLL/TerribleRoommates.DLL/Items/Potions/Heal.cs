using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerribleRoommates.DLL.Potions
{
    public class Heal : Potion //heal is a potion
    {
        public Heal(string name, int size, int effect)
            : base(name, size, effect) //calls base potion 
        {

        }
    }
}
