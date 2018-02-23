using System;

namespace GoblinBattle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g1 = new Goblin(100); //passing in hp
            Goblin g2 = new Goblin(100); //passing in hp

            Weapon g1w = new Weapon();
            Weapon g2w = new Weapon();

            g1w.Name = "Lightsaber";
            g1w.Damage = 9;
            g1.weapon = g1w;

            g2w.Name = "Blaster Pistol";
            g2w.Damage = 4;
            g2.weapon = g2w;

            Armor g1a = new Armor();
            Armor g2a = new Armor();


            g1a.Name = "The Force";
            g1a.Deflect = 10;
            g1.armor = g1a;

            g2a.Name = "Witty Comments";
            g2a.Deflect = 5;
            g2.armor = g2a;

            //g1.HitPoints = 10;
            g1.Name = "Jedi Master Bob";//Jedi Master Bob

            //g2.HitPoints = 10;
            g2.Name = "Tom Solo";//Tom Solo

            // they should take turns attacking, goblin 1 will go first
            int whoseTurn = 1;

            while (!g1.IsDead && !g2.IsDead)
            {
                if (whoseTurn == 1)
                {
                    g1.Attack(g2);                  
                    whoseTurn = 2;
                }                    
                else
                {
                    g2.Attack(g1);
                    whoseTurn = 1;
                }
            }

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }
    }
}
