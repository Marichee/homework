using System;
using System.Collections.Generic;
using System.Text;

namespace inheritance_library
{
    public class Manager : Employee
    {
        public Manager(string firstname, string lastname, double bonus) : base(firstname, lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
            Bonus = bonus;

        }
        private double Bonus { get; set; }
        public double AddBonus(double bonus)
        {
            return bonus += Bonus;
        }
        public override double GetSalary(double salary)
        {
            return base.GetSalary(salary) + AddBonus(Bonus);
        }
    }
}
