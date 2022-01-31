namespace Crossvertise.Calendar.Service.Business.Abstract
{
    using System;
    using System.Collections.Generic;

    using Crossvertise.Calendar.Service.Models;

    public interface IAppointmentService
    {
        /// <summary>
        /// Gets Appoint by given appointment's identity number
        /// </summary>
        AppointmentModel GetAppointmentDetail(long id);

        /// <summary>
        /// Gets the all appointments
        /// </summary>
        List<AppointmentModel> GetAllAppointments();

        /// <summary>
        /// Gets the all appointments between given datetime range
        /// </summary>
        List<AppointmentModel> GetAppointmentsByDate(DateTime startTime, DateTime endTime);
    }
}
