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
    public class SessionService : ISessionService
    {
        private readonly IRepository<SessionDto> _sessionRepository;
        private readonly IRepository<UserDto> _userRepository;
        private readonly IRepository<TicketsDto> _ticketRepository;
        CreateTicket _createTicket = new CreateTicket();
        public SessionService(IRepository<SessionDto> sessionRepository, IRepository<UserDto> userRepository, IRepository<TicketsDto> ticketRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        public IEnumerable<SessionModel> GetAllSeassons()
        {
            List<SessionModel> sessionList = new List<SessionModel>();
            var sessions = _sessionRepository.GetAll();
            foreach (var sessionModel in sessions)
            {
                if (_sessionRepository.GetById(sessionModel.Id).Numbers == null) continue;
                List<int> numbers = _createTicket.CreateTicketList(_sessionRepository.GetById(sessionModel.Id).Numbers);
                var model =
                new SessionModel()
                {
                    Id = sessionModel.Id,
                    Numbers = numbers,
                    WinnerBoard = sessionModel.WinnerBoard
                };
                sessionList.Add(model);
            }
            return sessionList;
        }

        public SessionModel GetSessionById(int id)
        {
            var sesionDto = _sessionRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (sesionDto == null) return null;
            if (sesionDto.Numbers == null) return null;
            return new SessionModel()
            {
                Numbers = _createTicket.CreateTicketList(sesionDto.Numbers),
                WinnerBoard = sesionDto.WinnerBoard
            };
        }

        public List<UserDto> GetWinnerList(List<int> numbers)
        {
            List<UserDto> winnerList = new List<UserDto>();
            var lastSession = _sessionRepository.GetAll().Last();
            var users = _ticketRepository.GetAll().Where(x => x.SessionId == lastSession.Id);
            foreach (var user in users)
            {
                int prize = 0;
                var userFound = _userRepository.GetAll().FirstOrDefault(x => x.Id == user.UserId);
                var ticketList = _createTicket.CreateTicketList(user.Ticket);
                foreach (var ticketNum in ticketList)
                {
                    foreach (var number in numbers)
                    {
                        if (number == ticketNum)
                        {
                            prize++;
                        }
                    }
                }
                switch (prize)
                {
                    case 7:
                        winnerList.Add(userFound);
                        userFound.Prize = 7;
                        break;
                    case 6:
                        winnerList.Add(userFound);
                        userFound.Prize = 6;
                        break;
                    case 5:
                        winnerList.Add(userFound);
                        userFound.Prize = 5;
                        break;
                    case 4:
                        winnerList.Add(userFound);
                        userFound.Prize = 4;
                        break;
                    case 3:
                        winnerList.Add(userFound);
                        userFound.Prize = 3;
                        break;
                }
            }
            return winnerList;
        }
        public void StartSession()
        {
            var model = _sessionRepository.GetAll().Last();
            List<int> modelNumbers = new List<int>();
            var ran = new Random();
            for (var n = 0; modelNumbers.Count() < 8; n++)
            {
                n = ran.Next(1, 38);
                if (!modelNumbers.Contains(n)) { modelNumbers.Add(n); }
            }

            //list for checking winnerlist
            // List<int> modelNumbers = new List<int>() { 1, 2, 33, 23, 36, 6, 7 };

            var winnerList = GetWinnerList(modelNumbers);
            model.Winners = winnerList;
            var numberString = _createTicket.CreateTicketString(modelNumbers);
            numberString = numberString.Remove(numberString.Length - 1);
            model.Numbers = numberString;
            string winnerBoard = "";
            foreach (var winner in winnerList)
            {
                winnerBoard += $"#. {winner.FirstName} {winner.LastName} Prize:{(Prize)winner.Prize} ";
            }
            if (winnerBoard == "") model.WinnerBoard = "There is no winner";
            else { model.WinnerBoard = winnerBoard; }
            _sessionRepository.Update(model);
            var session = new SessionDto();
            _sessionRepository.Add(session);
        }
    }
}
