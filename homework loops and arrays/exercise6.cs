using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] {  };
            Console.WriteLine("Enter name:");
            string inputName = Console.ReadLine();
            Array.Resize(ref names, names.Length + 1);
            names[names.Length - 1] = inputName;
            Console.WriteLine("All names:");
            foreach (string namesAll in names)
            {
                Console.WriteLine(namesAll);
            }
            string input;
            do
            {
                Console.WriteLine("Do you want to enter another name?(Y/N)");
                input = Console.ReadLine();

                if (input == "Y")
                {

                    Console.WriteLine("Enter name");
                    string inputN = Console.ReadLine();
                    Array.Resize(ref names, names.Length + 1);
                    names[names.Length - 1] = inputN;
                    Console.WriteLine("All names:");
                    foreach (string allNames in names)
                    {
                        Console.WriteLine(allNames);
                    }
                }
                else if (input == "N")
                {

                    break;
                }
                else
                {
                    Console.WriteLine("Wrong letter");

                }
            } while (input == "Y");
            Console.ReadLine();
        }
    }
}
