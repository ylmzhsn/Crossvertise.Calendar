namespace Crossvertise.Calender.Data.Entities
{
    
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    using Crossvertise.Calender.Data.Abstract;

    /// <summary>
    /// Appointments 
    /// </summary>
    public class Appointment : BaseEntity<long>
    {
        public Appointment()
        {
            Attendees = new List<User>();
        }

        /// <summary>
        /// Unique Id of Organizer of the Appointment
        /// </summary>
        public long OrganizerId { get; set; }

        /// <summary>
        /// Organizer of Appointment
        /// </summary>
        [JsonIgnore]
        public virtual User Organizer { get; set; }

        /// <summary>
        /// Description of Appointment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date of Appointment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Attendees of Appointment
        /// </summary>
        public ICollection<User> Attendees { get; set; }

        /// <summary>
        /// User Appointment
        /// </summary>
        public List<UserAppointment> UserAppointment { get; set; }

    }
}
