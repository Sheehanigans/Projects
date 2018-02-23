using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; set; }
        public Board PlayerBoard { get; set; } /*= new Board();*/
        public int PlayerNumber { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}