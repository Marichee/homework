using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace DataModels
{
    public class LotoAppDbContext : DbContext
    {
        public LotoAppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<TicketsDto> Tickets { get; set; }
        public DbSet<SessionDto> Sessions { get; set; }
        public string HashedDataMethod(string word)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(word));
            var hashedData = Encoding.ASCII.GetString(md5Data);
            return hashedData;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TicketsDto>().HasOne(x => x.User).WithMany(x => x.TicketList).HasForeignKey(x => x.UserId);
            builder.Entity<TicketsDto>().HasOne(x => x.Session).WithMany(x => x.Tickets).HasForeignKey(x => x.SessionId);

            builder.Entity<UserDto>().HasData(
                    new UserDto()
                    {
                        Id = 1,
                        FirstName = "Marija",
                        LastName = "Prosheva",
                        Username = "administrator",
                        Password = HashedDataMethod("admin"),
                        Role = 1
                    },
                new UserDto()
                {
                    Id = 2,
                    FirstName = "Elena",
                    LastName = "Ristova",
                    Username = "elichka",
                    Email = "elena@gmail.com",
                    Password = HashedDataMethod("abc"),
                    Role = 2
                });
            builder.Entity<SessionDto>().HasData(
                new SessionDto()
                {
                    Id = 1,
                    Numbers = "01,02,03,04,05,06,07 ",
                    WinnerBoard = "#Marija Prosheva Prize:Car"
                },
                  new SessionDto()
                  {
                      Id = 2
                  });
            builder.Entity<TicketsDto>().HasData(
               new TicketsDto()
               {
                   Id = 1,
                   Ticket = "01,02,03,04,05,06,07 ",
                   UserId = 1,
                   SessionId = 2
               }, new TicketsDto()
               {
                   Id = 2,
                   Ticket = "01,02,03,04,05,06,07 ",
                   UserId = 1,
                   SessionId = 2
               });
        }
    }
}
