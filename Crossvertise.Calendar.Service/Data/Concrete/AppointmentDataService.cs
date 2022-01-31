namespace Crossvertise.Calendar.Service.Data.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using Crossvertise.Calendar.Service.Data.Abstract;
    using Crossvertise.Calender.Data.Abstract;
    using Crossvertise.Calender.Data.Entities;

    public class AppointmentDataService : IAppointmentDataService
    {
        private readonly IApplicationContext _applicationContext;

        /// <summary>
        /// ctor
        /// </summary>
        public AppointmentDataService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        /// <summary>
        /// Gets Appoint by given appointment's identity number
        /// </summary>
        public Appointment GetAppointment(long id)
        {
            return _applicationContext.Appointments
                .Include(x => x.Attendees)
                .Include(x => x.Organizer)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets the all appointments
        /// </summary>
        public List<Appointment> GetAllAppointments()
        {
            return _applicationContext.Appointments.Include(x => x.Attendees).ToList();
        }

        /// <summary>
        /// Gets the all appointments between given datetime range
        /// </summary>
        public List<Appointment> GetAppointmentsByDate(DateTime startTime, DateTime endTime)
        {
            return _applicationContext.Appointments
                .Include(x => x.Attendees)
                .Include(x => x.Organizer)
                .Where(x => x.Date >= startTime && x.Date <= endTime).ToList();
        }
    }
}
