using System;

namespace GoblinBattle.UI
{
    class Goblin
    {
        // we only need one rng for all goblin instances, so static
        public static Random _rng = new Random();

        public int VariableHitPoints { get; private set; }

        public Goblin(int hp)
        {
            HitPoints = hp;
        }

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                // check incoming value
                if (value < 0)
                    return;
                else // otherwise save it to the field
                    _hitPoints = value;
            }
        }

        public string Name { get; set; }
        public bool IsDead { get { return _hitPoints <= 0; } }
        public G1Weapons G1weapon { get; set; }
        public G2Weapons G2weapon { get; set; }
        public G1Armor G1armor { get; set; }
        public G2Armor G2armor { get; set; }


        // attack another goblin instance (target)
        public void Attack(Goblin target)
        {
            int damage = _rng.Next(30);
            if (target.Name == "Tom Solo")//FIND WAY TO SWITCH ATTACKERS 
            {
                damage += G1weapon.Damage;
                damage -= G1armor.Deflect;
                Console.WriteLine($"{Name} attacks {target.Name} with {G1weapon.Name} for {damage} damage! {G1armor.Name} protected {target.Name} for {G1armor.Deflect} points.");//change G1.armor to G2.armor... throws error

            }
            else if (target.Name == "Jedi Master Bob")
            {
                damage += G2weapon.Damage;
                damage -= G2armor.Deflect;
                Console.WriteLine($"{Name} attacks {target.Name} with {G2weapon.Name} for {damage} damage! {G2armor.Name} protected {target.Name} for {G2armor.Deflect} points.");
            }

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            // deduct damage
            _hitPoints -= damage;
            Console.WriteLine($"{Name} receives {damage} damage. They have {_hitPoints} health.");

            // should we die?
            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{Name} has died!");
            }
        }
    }
}
