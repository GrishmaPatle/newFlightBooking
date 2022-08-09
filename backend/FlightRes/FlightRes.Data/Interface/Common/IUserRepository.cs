using FlightRes.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Interface
{
    public interface IUserRepository
    {
        Task<UserDetail> Register(UserDetail user);

    }
}
