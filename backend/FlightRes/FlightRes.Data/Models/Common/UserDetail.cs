using FlightRes.Data.Enums;
using FlightRes.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightRes.Data.Models.Common
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string FirstName { get; set; }

        [Required, MaxLength(60)]
        public string LastName { get; set; }

        [Required, MaxLength(60)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Age{ get; set; }

        [Required, MinLength(60, ErrorMessage = "Address1 should contain 60 character")]
        public string Address1 { get; set; }

        [Required, MinLength(60,ErrorMessage = "Address2 should contain 60 character")]
        public string Address2 { get; set; }

        [Required]
        public int Pincode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
