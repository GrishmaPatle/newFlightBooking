using FlightRes.User.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightRes.Data.Interface.User
{
    public interface ISearchRepository
    {
        Task<List<object>> Search(SearchFilter searchFilter);
        
    }
}
