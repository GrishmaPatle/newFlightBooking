using FlightRes.Data.DBContext;
using FlightRes.Data.Interface;
using FlightRes.Data.Models.Common;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FlightResDBContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserRepository(FlightResDBContext flightResDBContext, IPublishEndpoint publishEndpoint)
        {
            _context = flightResDBContext;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<UserDetail> Register(UserDetail user)
        {
            if (user != null)
            {
                await _context.UserDetails.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return user;
        }
    }
}
