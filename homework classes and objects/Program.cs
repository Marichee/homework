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
            //#region Exercise 3
            //Student[] arrStudents = new Student[] {
            //    new Student("Bob", "G1", "Web Developemt"),
            //    new Student("Jill", "G2", "Design"),
            //    new Student("Greg", "G1", "Networks"),
            //    new Student("Anne", "G3", "Web Developemt"),
            //    new Student("Will", "G3", "Design")
            //};

            //Console.WriteLine("Enter a student name");
            //string studentName = Console.ReadLine();
            //FindStudent(arrStudents, studentName);
            //#endregion
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
        //static void FindStudent(Student[] students, string name)
        //{
        //    bool studentFound = false;
        //    while (studentFound == false)
        //    {
        //        foreach (var student in students)
        //        {
        //            if (name.ToLower() == student.Name.ToLower())
        //            {
        //                Console.WriteLine($"Student found: \n Name: {student.Name} \n Group: {student.Group} \n Academy: {student.Academy}");
        //                studentFound = true;
        //            }
        //        }
        //        if (studentFound == false)
        //        {
        //            Console.WriteLine("There is no such student, please try again");
        //            name = Console.ReadLine();
        //        }
        //    }
        //    Console.ReadLine();
        //}
    }



}


