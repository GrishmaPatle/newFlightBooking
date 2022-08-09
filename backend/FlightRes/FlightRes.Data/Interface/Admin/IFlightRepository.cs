using FlightRes.Data.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Interface.Admin
{
    public interface IFlightRepository
    {
        Task<Flight> Add(Flight flight);

        Task<Flight> Edit(Flight flight);

        Task<int> Delete(int id);

        Task<List<Flight>> GetAirlines();

        Task<Flight> GetAirline(int id);
    }
}
