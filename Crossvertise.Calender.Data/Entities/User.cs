namespace Crossvertise.Calender.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Crossvertise.Calender.Data.Abstract;

    public class User : BaseEntity<long>
    {
        public User()
        {
            AttendeeAppointments = new List<Appointment>();
            OrganizedAppointments = new List<Appointment>();
        }

        /// <summary>
        /// Users full name
        /// </summary>
        [MaxLength(150)]
        public string UserName { get; set; }

        /// <summary>
        /// User Appointment
        /// </summary>
        public List<UserAppointment> UserAppointment { get; set; }

        /// <summary>
        /// Appointments organized by user
        /// </summary>
        public ICollection<Appointment> OrganizedAppointments { get; set; }

        /// <summary>
        /// Appointments that user participate as attendee
        /// </summary>
        public ICollection<Appointment> AttendeeAppointments { get; set; }

    }
}
