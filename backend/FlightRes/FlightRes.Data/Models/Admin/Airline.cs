using FlightRes.Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightRes.Data.Models.Admin
{
    public class Airline
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public  string Name { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual Ticket Ticket { get; set; }

    }
}
