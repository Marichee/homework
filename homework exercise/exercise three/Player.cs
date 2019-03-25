using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_three
{
    class Player
    {
        public Player(string userName,int score)
        {
            UserName = userName;
            Score = score;

        }
        public string UserName { get; set; }
        public int Score { get; set; }
    }
}
