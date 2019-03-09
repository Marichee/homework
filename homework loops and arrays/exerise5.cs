using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            int sum = 0;
            Console.WriteLine("Enter 5 numbers:");

            {
                for (int i = 0; i < array.Length; i++)
                {
                    string input = Console.ReadLine();
                    var isNumeric = int.TryParse(input, out int number);
                    if (isNumeric == true)
                    {
                        int value = int.Parse(input);
                        array[i] += value;
                        sum += number;
                        Console.WriteLine($"Elements in array: {array[0]}, {array[1]}, {array[2]}, {array[3]}, {array[4]};");
                    }
                    else
                    {
                        Console.WriteLine("ERROR! Only numbers");
                        break;
                    }
                }
            }
            Console.WriteLine($"Sum of this elements:{sum};");
            Console.ReadLine();
        }
    }
}

