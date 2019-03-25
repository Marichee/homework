using System;
using System.Collections.Generic;
using System.Text;

namespace inheritance_library
{
    public class SalesPerson : Employee
    {
        public SalesPerson(string firstname, string lastname) : base(firstname, lastname)
        {
            Salary = 500;
            Role = Role.Sales;

        }
        private double SuccessSaleRevenue { get; set; }
        public void AddSuccessRevenue(double revenue)
        {
            SuccessSaleRevenue = revenue;
        }
        public override double GetSalary(double salary)
        {
            return base.GetSalary(salary) + CalculateBonus();
        }
        public double CalculateBonus()
        {
            if (SuccessSaleRevenue <= 2000) { return 500; }
            else if ((SuccessSaleRevenue > 2000) && (SuccessSaleRevenue <= 5000))
            {
                return 1000;
            }
            return 1500;
        }
    }
}
