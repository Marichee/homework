using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5_date
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Today;
            Console.WriteLine("Today is: " + dateTime);
            Console.WriteLine("Three days from now: "+dateTime.AddDays(3));
            Console.WriteLine("One month from now: " + dateTime.AddMonths(1));
            Console.WriteLine("One month and three days from now: " + dateTime.AddMonths(1).AddDays(3));
            Console.WriteLine("One year and two months ago from now: " + dateTime.AddYears(-1).AddMonths(-2));
            Console.WriteLine("Current month with words: "+dateTime.ToString("MMMM"));
            Console.WriteLine("Current year: "+dateTime.Year);
            Console.ReadLine();
        }
    }
}
