using DataAccess;
using DataModels;
using Models;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly IRepository<TicketsDto> _ticketRepository;
        private readonly IRepository<SessionDto> _sessionRepository;
        CreateTicket _createTicket = new CreateTicket();
        public TicketService(IRepository<UserDto> userRepository, IRepository<TicketsDto> ticketRepository, IRepository<SessionDto> sessionRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
        }
        public bool AddTicket(TicketModel model)
        {
            var ticketList = CreateTicket(model.Ticket);
            var session = _sessionRepository.GetAll().Last().Id;
            if (ticketList.Count() == 7)
            {
                var ticketString = _createTicket.CreateTicketString(ticketList);
                ticketString = ticketString.Remove(ticketString.Length - 1);
                var user = _userRepository.GetAll().SingleOrDefault(x => x.Id == model.UserId);
                if (user == null) { throw new Exception("User was not found"); }
                else
                {
                    TicketsDto ticket = new TicketsDto()
                    {
                        UserId = user.Id,
                        Ticket = ticketString,
                        SessionId = session
                    };
                    _ticketRepository.Add(ticket);
                }
                return true;
            }
            return false;
        }
        public TicketModel GetTicket(int id, int userId)
        {
            var ticketId = _ticketRepository.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId);
            TicketModel ticket = new TicketModel()
            {
                Id = ticketId.Id,
                Ticket = _createTicket.CreateTicketList(ticketId.Ticket)
            };
            return ticket;
        }

        public IEnumerable<TicketModel> GetUserTickets(int userId)
        {
            var user = _ticketRepository.GetAll().FirstOrDefault(x => x.UserId == userId);
            if (user == null) return null;
            return _ticketRepository.GetAll().Where(x => x.UserId == userId)
                .Select(x => new TicketModel()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Ticket = _createTicket.CreateTicketList(x.Ticket)
                });
        }
        public List<int> CreateTicket(List<int> model)
        {
            List<int> ticketList = new List<int>();
            foreach (var number in model)
            {
                if (number > 0 && number <= 37)
                {
                    if (!ticketList.Contains(number)) { ticketList.Add(number); }
                }
            }
            return ticketList;
        }
    }
}
