using FlightRes.Data.DBContext;
using FlightRes.Data.Interface;
using FlightRes.Data.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using FlightRes.RabbitMQ;

namespace FlightRes.Data.Repositories.Admin
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly FlightResDBContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public AirlineRepository(FlightResDBContext flightResDBContext, IPublishEndpoint publishEndpoint)
        {
            _context = flightResDBContext;
            _publishEndpoint = publishEndpoint;
        }

        //public async Task<Airline> Add(Airline airline)
        //{
        //    if (airline != null)
        //    {
        //        airline.CreatedDate = DateTime.Now;
        //        await _context.Airlines.AddAsync(airline);
        //        //await _publishEndpoint.Publish<RabbitMqModel>(new
        //        //{
        //        //    airline.Name,
        //        //    airline.Owner,
        //        //    airline.Logo,
        //        //    airline.ContactNumber,
        //        //});

        //        //await _context.SaveChangesAsync();
        //        //return airline;
        //    }
        //    return airline;
        //}

        public async Task<Airline> Add(Airline airline)
        {
            if (airline != null)
            {
                airline.CreatedDate = DateTime.Now;

                await _context.Airlines.AddAsync(airline);
                await _context.SaveChangesAsync();
                return airline;
            }
            return airline;
        }

        public async Task<int> Delete(int id)
        {
            if (id > 0)
            {
                Airline airline = await _context.Airlines.FirstOrDefaultAsync(air => air.Id == id);
                if (airline != null)
                {
                    _context.Airlines.Remove(airline);
                    await _context.SaveChangesAsync();
                    return id;
                }

            }
            return id;

        }

        public async Task<Airline> Edit(Airline airline)
        {

            Airline airl = await _context.Airlines.FirstOrDefaultAsync(air => air.Id == airline.Id);
            if (airline != null)
            {
                airl.Id = airline.Id;
                airl.Name = airline.Name;
                airl.Logo = airline.Logo;
                airl.Owner = airline.Owner;
                airl.ContactNumber = airline.ContactNumber;
                airl.UpdatedDate = DateTime.Now;
                  
                _context.Airlines.Update(airl);
                await _context.SaveChangesAsync();
                return airl;
            }

            return airl;
        }

        public async Task<Airline> GetAirline(int id)
        {
            return await _context.Airlines.FirstOrDefaultAsync(air => air.Id == id);
        }

        public async Task<List<Airline>> GetAirlines()
        {
            return (List<Airline>)await _context.Airlines.ToListAsync();
        }
    }
}
