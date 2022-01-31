namespace Crossvertise.Calendar.Web.Models
{
    using System.Collections.Generic;

    using Crossvertise.Calendar.Service.Models;
    
    /// <summary>
    /// Calendar view model
    /// </summary>
    public class CalendarViewModel : ChoosenMonthViewModel
    {
        public List<AppointmentModel> Appointments { get; set; }
    }
}
