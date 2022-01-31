namespace Crossvertise.Calendar.Service.Business.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Crossvertise.Calendar.Service.Business.Abstract;
    using Crossvertise.Calendar.Service.Data.Abstract;
    using Crossvertise.Calendar.Service.Models;
    using Crossvertise.Calender.Data.Entities;

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentDataService _appointmentDataService;

        public AppointmentService(IAppointmentDataService appointmentDataService)
        {
            _appointmentDataService = appointmentDataService;
        }

        /// <summary>
        /// Gets Appoint by given appointment's identity number
        /// </summary>
        public AppointmentModel GetAppointmentDetail(long id)
        {
            if (id == default)
            {
                return null;
            }

            var appointment = _appointmentDataService.GetAppointment(id);

            var response = new AppointmentModel
            {
                Id = appointment.Id,
                OrganizerName = appointment.Organizer.UserName,
                Date = appointment.Date,
                Description = appointment.Description,
                Attendees = appointment.Attendees.Select(x => x.UserName).ToList()
            };

            return response;
        }

        /// <summary>
        /// Gets the all appointments
        /// </summary>
        public List<AppointmentModel> GetAllAppointments()
        {
            var appointments = _appointmentDataService.GetAllAppointments();

            var response = appointments.Select(appointment =>
                new AppointmentModel
                {
                    Id = appointment.Id,
                    OrganizerName = appointment.Organizer.UserName,
                    Date = appointment.Date,
                    Description = appointment.Description,
                    Attendees = appointment.Attendees.Select(x => x.UserName).ToList()
                }).ToList();

            return response;
        }

        /// <summary>
        /// Gets the all appointments between given datetime range
        /// </summary>
        public List<AppointmentModel> GetAppointmentsByDate(DateTime startTime, DateTime endTime)
        {
            var appointments = _appointmentDataService.GetAppointmentsByDate(startTime, endTime);

            var response = appointments.Select(appointment =>
                new AppointmentModel
                {
                    Id = appointment.Id,
                    OrganizerName = appointment.Organizer.UserName,
                    Date = appointment.Date,
                    Description = appointment.Description,
                    Attendees = appointment.Attendees.Select(x => x.UserName).ToList()
                }).ToList();

            return response;
        }
    }
}
