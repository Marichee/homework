using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_two
{
    class User
    {
      

        public User(int id, string userName, string password, string[] messages)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.Messages =messages;
     
  
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] Messages { get ; set; }
    }
}
