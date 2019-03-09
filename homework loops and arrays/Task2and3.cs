using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[20];
            Console.WriteLine("Enter 20  numbers:");
            for (int i = 0; i < numbers.Length; i++)
            {
                string input = Console.ReadLine();
                var isNumeric = int.TryParse(input, out int number);
                if (isNumeric == true)
                {
                    int value = int.Parse(input);
                    numbers[i] += value;
                }
                else
                {
                    Console.WriteLine("ERROR! Only numbers");
                    break;
                }
            }
            Console.WriteLine("All numbers");
            foreach (int allNumbers in numbers)
            {
                if (allNumbers == 0)
                {
                    Console.WriteLine("Skipped");
                    continue;
                }
                else if (allNumbers > 100 && allNumbers < 1000)
                {
                    Console.WriteLine("Stop printing");
                    break;
                }
                Console.WriteLine(allNumbers);
            }
            Console.ReadLine();
        }
    }
}
