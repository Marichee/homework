using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class TicketRepository:IRepository<TicketsDto>
    {
        private readonly LotoAppDbContext _context;
        public TicketRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Add(TicketsDto entity)
        {
            _context.Tickets.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TicketsDto entity)
        {
            _context.Tickets.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TicketsDto> GetAll()
        {
            return _context.Tickets;
        }

        public TicketsDto GetById(int id)
        {
            return _context.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TicketsDto entity)
        {
            _context.Tickets.Update(entity);
            _context.SaveChanges();
        }
    }
}
