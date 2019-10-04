using DataModels;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
  public  interface ISessionService
    {
        IEnumerable<SessionModel> GetAllSeassons();
        SessionModel GetSessionById(int id);
        void StartSession();
    }
}
