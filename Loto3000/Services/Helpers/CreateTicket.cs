using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Helpers
{
    public class CreateTicket
    {
        public List<int> CreateTicketList(string ticket)
        {
            List<int> ticketList = new List<int>();
            List<string> stringNumbers = new List<string>();
            string number = "";
            for (var i = 0; i < ticket.Length - 1; i += 3)
            {
                char[] comma = { ',' };
                ticket.Trim(comma);
                number = ticket[i].ToString() + ticket[i + 1].ToString();

                stringNumbers.Add(number);
            }
            foreach (var num in stringNumbers)
            {
                int.TryParse(num, out int numbers);
                ticketList.Add(numbers);
            }
            return ticketList;
        }
        public string CreateTicketString(List<int> ticketList)
        {
            string ticketString = "";

            foreach (var ticketNumber in ticketList)
            {
                if (ticketNumber < 10 && ticketNumber > 0)
                {
                    ticketString += ticketNumber.ToString("0,");
                }
                ticketString += ticketNumber.ToString() + ",";
            }
            return ticketString;
        }
    }
}
