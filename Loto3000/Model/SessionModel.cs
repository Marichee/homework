using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public List<int> Numbers { get; set; }
        public string WinnerBoard { get; set; }
    }

}
