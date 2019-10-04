using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
   public class SessionRepository:IRepository<SessionDto>
    {
        private readonly LotoAppDbContext _context;
        public SessionRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Add(SessionDto entity)
        {
            _context.Sessions.Add(entity);
            _context.SaveChanges();
   
        }

        public void Delete(SessionDto entity)
        {
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<SessionDto> GetAll()
        {
            return _context.Sessions;
        }

        public SessionDto GetById(int id)
        {
            return _context.Sessions.FirstOrDefault(x => x.Id == id);
        }

        public void Update(SessionDto entity)
        {
            _context.Sessions.Update(entity);
            _context.SaveChanges();
        }
    }
}
