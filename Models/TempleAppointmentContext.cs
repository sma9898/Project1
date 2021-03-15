using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class TempleAppointmentContext : DbContext
    {
        public TempleAppointmentContext (DbContextOptions<TempleAppointmentContext> options) : base (options)
        {}

        public DbSet<Group> Groups { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        
    }
}
