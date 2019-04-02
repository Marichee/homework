using FighterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterApp.Classes
{
    public class ProFighter : Fighter, IBox, IStreet
    {
        public ProFighter(double health, double powerPunch, double speed, double experience) : base(health, powerPunch, speed)
        {
            Health = health;
            Experience = experience;
            PowerPunch = powerPunch;
            Speed = speed;
        }
        public double Experience { get; set; }
        public double Health { get; set; }
        public override bool IsDizzy()
        {
            if (Health < 10)
            {
                return true;
            }
            return false;
        }
        public override void TakeDamage()
        {
            Health = 0;
        }
        public override void TakeDamage(double damage)
        {
            Health -= damage;
        }
        public void DoStreet(Fighter opponent)
        {
            opponent.TakeDamage(Experience);
            if (IsDizzy() == true) { TakeDamage(); Finisher(this); }
        }
        public void DoBoxing(Fighter opponent)
        {
            opponent.TakeDamage(Experience);
            if (IsDizzy() == true) { TakeDamage(); Finisher(this); }
        }
        protected override void Finisher(Fighter opponent)
        {
            Console.WriteLine($"Profighter health :{Health}");
        }
    }
}
