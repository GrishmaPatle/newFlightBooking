using FlightRes.Data.DBContext;
using FlightRes.Data.Interface.User;
using FlightRes.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Repositories.User
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FlightResDBContext _context;

        public TicketRepository(FlightResDBContext flightResDBContext)
        {
            _context = flightResDBContext;
        }
        public Ticket GetByPNR(int pnr)
        {
            Ticket ticket =  _context.Tickets.FirstOrDefault(t => t.PNR == pnr);

            return  ticket;
        }
    }
}
