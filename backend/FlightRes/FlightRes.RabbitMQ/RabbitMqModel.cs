using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightRes.RabbitMQ
{
    public interface RabbitMqModel
    {        
        public string Name { get; set; }       
        public string Owner { get; set; }

        public string logo { get; set; }

        public int ContactNumber { get; set; }

       

    }
}
