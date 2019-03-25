using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_one
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "y";
            do
            {
                Console.WriteLine("Enter number");
                string numb = Console.ReadLine();
                bool isNumeric = Double.TryParse(numb, out double number);
                if (isNumeric == true)
                {
                    Console.WriteLine("Stats for number: " + number + "\n" + NumberPositive(number) + "\n" + NumberEven(number) + "\n" + NumberDecimal(number));
                    Console.WriteLine("Do you want to enter another number(Y/X) ");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "Y")
                    {
                        continue;
                    }
                    else if (input.ToUpper() == "N")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("only numbers");
                }
            } while (input.ToUpper() == "Y");

            Console.ReadLine();
        }
        public static string NumberPositive(double numbers)
        {
            if (numbers > 0)
            {
                return "number positive";
            }
            else
            {
                return "number negative";
            }
        }
        public static string NumberEven(double numbers)
        {
            if (numbers % 2 == 0)
            {
                return "number even";
            }
            else
            {
                return "number odd";
            }
        }
        public static string NumberDecimal(double numbers)
        {
            if (numbers % 1 > 0)
            {
                return "number is decimal";
            }
            else
            {
                return "number is integer";
            }
        }
    }
}
