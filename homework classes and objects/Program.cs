using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Student
            Student[] students = new Student[]
            {
                new Student("Marija","G5","Design"),
                    new Student("Miro","G2","Web developer"),
                        new Student("Elena","G4","Computer network"),
                            new Student("Daniel","G6","Software testing"),
                                new Student("Zoran","G1","Design"),

            };
            Console.WriteLine("Enter student name: ");
            string studentName = Console.ReadLine();
            Student(students, studentName);
            #endregion
        }
        public static void Student(Student[] students, string studentName)
        {
            bool searchStudent = false;
            while (searchStudent == false)
            {
                foreach (var student in students)
                {
                    if (studentName == student.Name.ToLower())
                    {
                        Console.WriteLine($"Student : \n Name: {student.Name} \n Group: {student.Group} \n Academy: {student.Academy}");
                        searchStudent = true;
                    }
                }
                if (searchStudent == false)
                {
                    Console.WriteLine($"There is no such student");
                    studentName = Console.ReadLine();
                }
            }
            Console.ReadLine();
        }

    }
}


