using FlightRes.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightRes.Data.Interface.User
{
    public interface ITicketRepository
    {
        Ticket GetByPNR(int pnr);
    }
}
