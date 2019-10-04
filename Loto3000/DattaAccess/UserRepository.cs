using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class UserRepository:IRepository<UserDto>
    {
        private readonly LotoAppDbContext _context;
        public UserRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Add(UserDto entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserDto entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _context.Users;
        }

        public UserDto GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public void Update(UserDto entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
