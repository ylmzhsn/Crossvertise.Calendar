namespace Crossvertise.Calendar.Service.Models
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    
    /// <summary>
    /// Appointment Data Transfer Object
    /// </summary>
    public class AppointmentModel
    {
        /// <summary>
        /// Unique Id of Appointment
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Organizer of Appointment
        /// </summary>
        [JsonProperty("organizerName")]
        public string OrganizerName { get; set; }

        /// <summary>
        /// Description of Appointment
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Date of Appointment
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Attendees of Appointment
        /// </summary>
        [JsonProperty("attendees")]
        public List<string> Attendees { get; set; }
    }
}
