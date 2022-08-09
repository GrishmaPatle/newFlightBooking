using FlightRes.Data.Interface.User;
using FlightRes.User.Service.Models;
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

    public class SearchController : ControllerBase
    {
        private ISearchRepository _searchRepository;
        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SearchFilter searchFilter)
        {
            return Ok(_searchRepository.Search(searchFilter));
        }


    }
}
