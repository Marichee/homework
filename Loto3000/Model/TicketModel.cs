using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class TicketModel
    {
        public int Id { get; set; }
        public List<int> Ticket { get; set; } 
        public int UserId { get; set; }
    }
}
