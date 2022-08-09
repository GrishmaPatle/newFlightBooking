using System;
using System.Collections.Generic;
using System.Text;

namespace FlightRes.Data.Models.User
{
    public interface IAuthRepository
    {
        string Login(Login login);
    }
}
