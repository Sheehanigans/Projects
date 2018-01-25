using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.DLL;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow game = new GameFlow();
            game.PlayGame();
        }
    }
}
