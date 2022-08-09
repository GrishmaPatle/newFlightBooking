using FlightRes.Data.DBContext;
using FlightRes.Data.Models.Common;
using FlightRes.Data.Models.User;
using FlightRes.Data.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightRes.Data.Repositories.User
{
    public class AuthRepository : IAuthRepository
    {

        private FlightResDBContext _context;
        private IConfiguration _config;


        public AuthRepository(FlightResDBContext flightResDBContext, IConfiguration config)
        {
            _context = flightResDBContext;
            _config = config;

        }
        public string Login(Login login)
        {
            if (login != null)
            {
                UserDetail userDetail = _context.UserDetails.FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());
                if (userDetail.Email != "" && userDetail.Password.ToLower() == login.Password.ToLower())
                {
                    var jwt = new JwtService(_config);
                    var token = jwt.GenerateSecurityToken(userDetail.Email);
                    return token;
                }
                return "Credential are wrong";
            }
            return "Credential are wrong";

        }
    }
}
