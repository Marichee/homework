using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Prize Prize { get; set; }
        public string Token { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        User = 2
    }
    public enum Prize
    {
        Car = 7,
        Vacation = 6,
        TV = 5,
        OneHundredDolars = 4,
        FiftyDolars = 3
    }
}
