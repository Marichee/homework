using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        UserModel LogIn(string username, string password);
        void Register(RegisterModel model);
        RegisterModel CheckUsername(RegisterModel model);
        RegisterModel GetUser(int id);
    }
}
