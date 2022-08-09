using FlightRes.Data.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Interface
{
    public interface IAirlineRepository
    {
        Task<Airline> Add(Airline airline);

        Task<Airline> Edit(Airline airline);

        Task<int> Delete(int id);

        Task<List<Airline>> GetAirlines();

        Task<Airline> GetAirline(int id);


    }
}
