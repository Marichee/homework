using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public class DiModule
    {
        public static IServiceCollection RegisterModuule(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<UserDto>, UserRepository>();
            services.AddTransient<IRepository<TicketsDto>, TicketRepository>();
            services.AddTransient<IRepository<SessionDto>, SessionRepository>();
            services.AddDbContext<LotoAppDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
