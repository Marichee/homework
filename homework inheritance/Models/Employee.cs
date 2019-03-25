using System;

namespace inheritance_library
{

    public class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Role Role { get; set; }
        protected double Salary { get; set; }
        public Employee(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string PrintInfo()
        {
            return $"{Firstname} {Lastname} {Salary}";
        }
        public virtual double GetSalary(double salary)
        {
            return Salary = salary;
        }
    }
}
