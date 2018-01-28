using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerribleRoommates.DLL.Weapons
{
    abstract public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int size, int damage)
            : base(name, size, ItemType.Weapon) //base is item 
        {
            Damage = damage;
        }
    }
}
