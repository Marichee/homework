using inheritance_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee ("Bob",  "Bobsky");
            emp.Role=Role.Other;       
            SalesPerson sale = new SalesPerson("Bill", "Billsky");
            emp.GetSalary(666);
            Manager manager = new Manager("Marija", "Prosheva",300);
            sale.AddSuccessRevenue(2000);
            Console.WriteLine(emp.PrintInfo());
            Console.WriteLine(sale.PrintInfo());
            Console.WriteLine("Employee Salary: " + emp.GetSalary(666));
            Console.WriteLine("Sales Person Salary: " + sale.GetSalary(666));
            Console.WriteLine("Manager Salary :" + manager.GetSalary(444));
            Console.ReadLine();
        }
    }
}
