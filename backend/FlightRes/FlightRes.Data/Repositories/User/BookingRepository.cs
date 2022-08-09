using FlightRes.Data.DBContext;
using FlightRes.Data.Interface.User;
using FlightRes.Data.Models.User;
using FlightRes.User.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Repositories.User
{

    public class BookingRepository : IBookingRepository
    {

        private FlightResDBContext _context;

        public BookingRepository(FlightResDBContext flightResDBContext)
        {
            _context = flightResDBContext;
        }
        
        public  Ticket Book(Ticket ticket)
        {
            if(ticket != null)
            {
                ticket.PNR = getPNR();
                ticket.SeatCost = getDiscount(ticket.SeatCost, ticket.Discount);
                 _context.Tickets.Add(ticket);
                 _context.SaveChanges();
            }
            return ticket;
        }


        public IEnumerable<Ticket> History(string emailid)
        {
            IEnumerable<Ticket> tickets = from t in _context.Tickets
                                   join u in _context.UserDetails
                                   on t.UserId equals u.Id
                                   where u.Email == emailid
                                   select t;

            return tickets;
        }

        public int Cancel(int pnr)
        {
            Ticket ticket = _context.Tickets.FirstOrDefault(t => t.PNR == pnr);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
                return pnr;

            }
            else
            {
                pnr = 0;
            }


            return pnr;
        }


        public int getPNR()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            return myRandomNo;
        }

        public int getDiscount(int price,int dis)
        {
            int total = price;          
            int disc = price*dis/ 100;
            return total - disc;
        }

    }
}
