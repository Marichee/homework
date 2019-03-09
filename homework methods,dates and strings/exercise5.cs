using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_age_calculatoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birthday date in format DD-MM-YYYY");
            string birthDay = Console.ReadLine();
            DateTime date = Convert.ToDateTime(birthDay);
            CalculateAge(date);
            Console.ReadLine();
        }

        public static int CalculateAge(DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;
            if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
            { years--; }
            Console.WriteLine("You are: " + years);
            return years;
        }


    }
}
