namespace Crossvertise.Calender.Data.Abstract
{
    using Microsoft.EntityFrameworkCore;

    using Crossvertise.Calender.Data.Entities;
    
    /// <summary>
    /// Db Context
    /// </summary>
    public interface IApplicationContext
    {
        DbSet<Appointment> Appointments { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<UserAppointment> UserAppointments { get; set; }
    }
}
