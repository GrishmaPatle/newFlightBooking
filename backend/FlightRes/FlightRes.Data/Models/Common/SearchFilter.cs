using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRes.User.Service.Models
{

    public class SearchFilter
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string FromPlace { get; set; }

        public string ToPlace { get; set; }
    }
}
