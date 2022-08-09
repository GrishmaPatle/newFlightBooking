using FlightRes.Data.DBContext;
using FlightRes.Data.Interface.Admin;
using FlightRes.Data.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightRes.Data.Repositories.Common
{
    public class FlightRepository : IFlightRepository
    {
        private FlightResDBContext _context;


        public FlightRepository(FlightResDBContext context)
        {
            _context = context;
        }
        public async Task<Flight> Add(Flight flight)
        {
            if (flight != null)
            {
                flight.CreatedDate = DateTime.Now;

                await _context.Flights.AddAsync(flight);
                await _context.SaveChangesAsync();
                return flight;
            }
            return flight;

        }

        public async Task<int> Delete(int id)
        {
            Flight flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);

            if(flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
                return id;
            }
            return id;
        }

        public async Task<Flight> Edit(Flight flight)
        {
            Flight fli = await _context.Flights.FirstOrDefaultAsync(f => f.Id == flight.Id);

            if (flight != null)
            {
                
                _context.Flights.Update(flight);
                await _context.SaveChangesAsync();
                return fli;
            }
            return fli;
        }

        public async Task<Flight> GetAirline(int id)
        {
            return await _context.Flights.FirstOrDefaultAsync(air => air.Id == id);
        }

        public async Task<List<Flight>> GetAirlines()
        {
            return await _context.Flights.ToListAsync();
        }
    }
}
