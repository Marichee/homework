using FighterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FighterApp.Classes
{
    class RockStarFighter : Fighter, IStreet, IBox, IMuayThai
    {
        public RockStarFighter(double health, double powerPunch, double speed, double reputation) : base(health, powerPunch, speed)
        {
            PowerPunch = powerPunch;
            Speed = speed;
            Health = health;
            Reputation = reputation;
        }
        public double Reputation { get; set; }
        public double Health { get; set; }
        public override void TakeDamage()
        {
            Health = 0;
        }
        public override void TakeDamage(double damage)
        {
            Health -= damage;
        }
        public override bool IsDizzy()
        {
            if (Health < 10)
            {
                return true;
            }
            return false;
        }
        protected override void Finisher(Fighter opponent)
        {
            Console.WriteLine($"Rock Star fighter health:{Health}");
        }
        public void DoStreet(Fighter opponent)
        {
            opponent.TakeDamage(Reputation);
            if (IsDizzy() == true) { TakeDamage(); Finisher(this); }
        }
        public void DoBoxing(Fighter opponent)
        {
            opponent.TakeDamage(Reputation);
            if (IsDizzy() == true) { TakeDamage(); Finisher(this); }
        }
        public void DoMuayThai(Fighter opponent)
        {
            opponent.TakeDamage(Reputation);
            if (IsDizzy() == true) { TakeDamage(); Finisher(this); }
        }
    }
}
