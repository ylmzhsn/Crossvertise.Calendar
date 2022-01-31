namespace Crossvertise.Calendar.Web.Models
{
    using Crossvertise.Calendar.Service.Models;

    /// <summary>
    /// Appointment detail view model
    /// </summary>
    public class AppointmentViewModel : CalendarViewModel
    {
        public AppointmentModel Appointment { get; set; }
    }
}
