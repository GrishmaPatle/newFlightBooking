using FlightRes.Data.Enums;
using FlightRes.Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightRes.Data.Models.Admin
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Airline")]
        public int AirlineId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int FlightNumber { get; set; }

        [Required]
        public string FromPlace { get; set; }

        [Required]
        public string ToPlace { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public string ScheduledDays { get; set; }

        [Required]
        public string InstumentUsed { get; set; }

        [Required]
        public int TotalNumberOfBusinessClassSeats { get; set; }

        [Required]
        public int TotalNumberOfNonBusinessClassSeats { get; set; }

        [Required]
        public int CostOfBusinessClassSeats { get; set; }

        [Required]
        public int CostOfNumberOfNonBusinessClassSeats { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public int NumberOfRows { get; set; }

        [Required]
        public MealType MealType { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


        public virtual Airline Airline { get; set; }

        public virtual Ticket Ticket { get; set; }

    }
}
