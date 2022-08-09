using FlightRes.Data.DBContext;
using FlightRes.Data.Models.Admin;
using FlightRes.User.Service.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlightRes.Data.Interface.User;

namespace FlightRes.Data.Repositories.User
{
    public class SearchRepository : ISearchRepository
    {

        private readonly FlightResDBContext _context;

        public SearchRepository(FlightResDBContext flightResDBContext)
        {
            _context = flightResDBContext;
        }

        public async Task<List<object>> Search(SearchFilter searchFilter)
        {

            IEnumerable<object> flights = from f in _context.Flights
                          join a in _context.Airlines
                          on f.AirlineId equals a.Id
                          where (f.StartDateTime.Date >= searchFilter.FromDate.Date && f.EndDateTime.Date <= searchFilter.ToDate.Date) &&
                          (f.FromPlace.Equals(searchFilter.FromPlace.ToLower()) && f.ToPlace.Equals(searchFilter.ToPlace.ToLower()))
                          select new
                          {
                              FlightID = f.Id,
                              AirLineName = a.Name,
                              FlightName  = f.Name,
                              StartDate = f.StartDateTime,
                              EndDate = f.EndDateTime,
                              FormPalace = f.FromPlace,
                              ToPlace = f.ToPlace,
                              FlightNumber = f.FlightNumber,
                              ScheduledDays = f.ScheduledDays,
                              CostOfBusinessClassSeats = f.CostOfBusinessClassSeats,
                              CostOfNonBusinessClassSeats = f.CostOfNumberOfNonBusinessClassSeats
                          };

            return flights.ToList();

        } 
    }
}
