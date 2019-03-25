using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_three
{
    class TheAnswer
    {
   
        public TheAnswer(string answer, bool trueOrfalse)
        {
            Answer = answer;
            TrueOrFalse = trueOrfalse;
        }



        public string Answer { get; set; }
        public bool TrueOrFalse { get; set; }
 


    }
}
