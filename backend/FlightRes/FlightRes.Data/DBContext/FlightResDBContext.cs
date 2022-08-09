using FlightRes.Data.Models.Admin;
using FlightRes.Data.Models.Common;
using FlightRes.Data.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightRes.Data.DBContext
{
    public class FlightResDBContext : DbContext
    {
        public FlightResDBContext(DbContextOptions<FlightResDBContext> options)
      : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlightRes-Demo2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(b => b.Flight)
                .WithOne(a => a.Ticket)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<Airline> Airlines { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }


}
