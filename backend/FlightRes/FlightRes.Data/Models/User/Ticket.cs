using FlightRes.Data.Enums;
using FlightRes.Data.Models.Admin;
using FlightRes.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightRes.Data.Models.User
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Airline")]
        public int AirlineId { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }

        [ForeignKey("UserDetail")]
        public int UserId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerEmail { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool OptForMeal { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        public int PNR { get; set; }

        //public TicketStatus TicketStatus { get; set; }

        public int SeatCost { get; set; }

        public int Discount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual UserDetail UserDetail{ get; set; }

        public virtual Airline Airline{ get; set; }

        public virtual Flight Flight { get; set; }

        


    }
}
