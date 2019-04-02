using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterApp.Interfaces;

namespace FighterApp.Classes
{
    class StreetFighter : Fighter, IStreet
    {
        public StreetFighter(double health, double powerPunch, double speed, double streetCredit) : base(health, powerPunch, speed)
        {
            PowerPunch = powerPunch;
            Speed = speed;
            Health = health;
            StreetCredit = streetCredit;
        }
        public double StreetCredit { get; set; }
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
        public void DoStreet(Fighter opponent)
        {
            opponent.TakeDamage(StreetCredit);
            if (IsDizzy() == true) { TakeDamage(); Finisher(this); }
        }
        protected override void Finisher(Fighter opponent)
        {
            Console.WriteLine($"Street fighter health:{ Health}");
        }
    }
}
