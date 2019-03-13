using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        public Student(string name, string group, string academy)
        {
            this.Name = name;
            this.Group = group;
            this.Academy = academy;
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Academy { get; set; }
    }
}
