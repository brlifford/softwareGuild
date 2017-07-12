using System;

namespace GoblinBattle.UI
{
    class Goblin
    {
        // we only need one rng for all goblin instances, so static
        private static Random _rng = new Random();

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
        public bool HasArmor { get; set; }
        public bool HasWeapon { get; set; }
        public int MaxDamage { get; private set; } = 2;
        public int BaseDamage { get; private set; } = 2;
        public bool IsDead { get; private set; }
        public int AttackDamage { get; private set; }
        public int DamageTaken { get; private set; }

        // attack another goblin instance (target)
       
        public void Attack(Goblin target)
        {
            int damage = 0;
            AttackDamage = BaseDamage + MaxDamage;
            
            if (HasWeapon == true)
            {
                
                damage = _rng.Next(MaxDamage, AttackDamage);
            }
            else
            {
                damage = _rng.Next(BaseDamage);
            }

            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            if(HasArmor == true && damage != 0)
            {
                DamageTaken = damage - 1;
                _hitPoints -= DamageTaken;
            }
            else
            {
                DamageTaken = damage;
                _hitPoints -= DamageTaken;
            }
            // deduct damage
            
            Console.WriteLine($"{Name} receives {DamageTaken} damage. They have {_hitPoints} health.");

            // should we die?
            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{Name} has died!");
                IsDead = true;
            }
        }
    }
}
