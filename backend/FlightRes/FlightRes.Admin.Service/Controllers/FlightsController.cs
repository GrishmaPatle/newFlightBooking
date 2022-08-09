using FlightRes.Data.Interface.Admin;
using FlightRes.Data.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRes.Admin.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightRepository _flightRepository;

        public FlightsController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _flightRepository.GetAirlines());
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _flightRepository.GetAirline(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Flight airline)
        {
            return Ok(await _flightRepository.Add(airline));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Flight airline)
        {
            return Ok(await _flightRepository.Edit(airline));
        }


        [HttpDelete]
        public async Task<ActionResult> Put(int id)
        {
            return Ok(await _flightRepository.Delete(id));
        }
    }
}
