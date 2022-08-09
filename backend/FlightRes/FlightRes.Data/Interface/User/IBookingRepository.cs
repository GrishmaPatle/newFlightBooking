using FlightRes.Data.Models.User;
using FlightRes.User.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Interface.User
{
    public interface IBookingRepository
    {
        Ticket Book(Ticket ticket);
        IEnumerable<Ticket> History(string emailid);

        int Cancel(int pnr);
    }
}
