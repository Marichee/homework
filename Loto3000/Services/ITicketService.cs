using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public interface ITicketService
    {
        IEnumerable<TicketModel> GetUserTickets(int userId);
        TicketModel GetTicket(int id,int userId);
        bool AddTicket(TicketModel model);
    }
}
