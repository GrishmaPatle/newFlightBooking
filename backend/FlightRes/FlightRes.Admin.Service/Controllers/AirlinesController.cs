using FlightRes.Data.Interface;
using FlightRes.Data.Models.Admin;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class AirlinesController : ControllerBase
    {
        private IAirlineRepository _airlineRepository;

        public AirlinesController(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _airlineRepository.GetAirlines());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _airlineRepository.GetAirline(id));
        }

        //[HttpPost,Authorize (Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Airline airline)
        {
            return Ok(await _airlineRepository.Add(airline));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Airline airline)
        {
            return Ok(await _airlineRepository.Edit(airline));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Put(int id)
        {
            return Ok(await _airlineRepository.Delete(id));
        }
    }
}
