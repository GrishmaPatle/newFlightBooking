using FlightRes.Data.Interface.User;
using FlightRes.Data.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRes.User.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpPost("{flightid:int}")]
        public IActionResult Post(int flightid, [FromBody]Ticket ticket)
        {
            return Ok(_bookingRepository.Book(ticket));
        }


        [HttpGet("history/{emailid}") ,Authorize(Roles ="User")]
        public IActionResult Post(string emailid)
        {
            return Ok(_bookingRepository.History(emailid));
        }

        [HttpDelete("cancel/{pnr:int}")]
        public IActionResult Post(int pnr)
        {
            return Ok(_bookingRepository.Cancel(pnr));
        }
    }
}
