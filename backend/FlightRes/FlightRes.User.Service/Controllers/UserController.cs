using FlightRes.Data.Interface;
using FlightRes.Data.Models.Common;
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
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string Get()
        {
            return "message from user microservice";
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserDetail user)
        {
            UserDetail userDetail = await _userRepository.Register(user);
            return Ok(userDetail);
        }
    }
}
