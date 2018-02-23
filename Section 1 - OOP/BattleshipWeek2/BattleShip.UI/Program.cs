using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;

namespace BattleShip.UI
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            StartScreen splash = new StartScreen();
            splash.Splash();

            //ConsoleInput.PlayAgain();

            Gameplay gameTime = new Gameplay();
            gameTime.Play();


        }
    }
}
