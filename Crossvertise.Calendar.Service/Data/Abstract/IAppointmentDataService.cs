namespace Crossvertise.Calendar.Service.Data.Abstract
{
    using System;
    using System.Collections.Generic;

    using Crossvertise.Calender.Data.Entities;

    public interface IAppointmentDataService
    {
        /// <summary>
        /// Gets Appoint by given appointment's identity number
        /// </summary>
        Appointment GetAppointment(long id);

        /// <summary>
        /// Gets the all appointments
        /// </summary>
        List<Appointment> GetAllAppointments();

        /// <summary>
        /// Gets the all appointments between given datetime range
        /// </summary>
        List<Appointment> GetAppointmentsByDate(DateTime startTime, DateTime endTime);
    }
}
