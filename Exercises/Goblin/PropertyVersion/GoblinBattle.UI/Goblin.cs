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
        public Weapon weapon { get; set; }
        public Armor armor { get; set; }


        // attack another goblin instance (target)
        public void Attack(Goblin target)
        {
            int damage = _rng.Next(30);
            if (target.Name == "Tom Solo")//FIND WAY TO SWITCH ATTACKERS 
            {
                damage += weapon.Damage;
                damage -= armor.Deflect;
                Console.WriteLine($"{Name} attacks {target.Name} with {weapon.Name} for {damage} damage! {armor.Name} protected {target.Name} for {armor.Deflect} points.");
            }
            else if (target.Name == "Jedi Master Bob")
            {
                damage += weapon.Damage;
                damage -= armor.Deflect;
                Console.WriteLine($"{Name} attacks {target.Name} with {weapon.Name} for {damage} damage! {armor.Name} protected {target.Name} for {armor.Deflect} points.");
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
