using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//Facilitates Entity Framework Data Access Layer 
//mapping models to their database tables

namespace BookingSystem.Models
{
    public class RDSContext : DbContext
    {
        public DbSet<CampDate> CampDates { get; set; } 
        public DbSet<School> Schools { get; set; } 
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<School2> School2 { get; set; }

    }
}