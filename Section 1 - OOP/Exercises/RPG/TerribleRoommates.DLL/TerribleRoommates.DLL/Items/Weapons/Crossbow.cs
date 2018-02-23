using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerribleRoommates.DLL.Weapons
{
    public class Crossbow : Weapon // crossbow is a weapon 
    {
        public Crossbow(string name, int size, int damage)
            : base(name, size, damage) // calls base weapon 
        {

        }
    }
}
