namespace Crossvertise.Calender.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Crossvertise.Calender.Data.Abstract;
    using Crossvertise.Calender.Data.Entities;
    using Crossvertise.Calender.Data.Entities.Configuration;

    /// <summary>
    /// Db Context
    /// </summary>
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            ///
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserAppointmentConfiguration());
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAppointment> UserAppointments { get; set; }
    }
}
