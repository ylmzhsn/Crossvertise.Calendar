namespace Crossvertise.Calendar.Web.Controllers
{    
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Crossvertise.Calendar.Core.Enums;
    using Crossvertise.Calendar.Service.ApiClients;
    using Crossvertise.Calendar.Web.Models;

    public class CalendarController : Controller
    {       
        public async Task<IActionResult> Index()
        {
            var result = await AppointmentApiClient.GetAllAppointments();

            var model = new AppointmentViewModel()
            {
                Appointments = result,
                ChoosenMonth = Months.Jan
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments(int month)
        {
            var model = new AppointmentViewModel();

            if (month == default || month > 12 || month < 0)
            {
                return View("Index", model);
            }

            var today = DateTime.Now;

            var startTime = new DateTime(today.Year, month.GetHashCode(), 1);

            var endTime = new DateTime(today.Year, month, DateTime.DaysInMonth(today.Year, month), 23, 59, 59);

            var result = await AppointmentApiClient.GetAppointmentsByDate(startTime, endTime);

            model.Appointments = result;

            model.ChoosenMonth = (Months)month;

            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetail(long id)
        {
            var result = await AppointmentApiClient.GetAppointmentDetail(id);

            var model = new AppointmentViewModel();

            if (result != null)
            {
                model.Appointment =  result;

                model.ChoosenMonth = (Months)result.Date.Month;

                var today = DateTime.Now;

                var startTime = new DateTime(today.Year, result.Date.Month, 1);

                var endTime = new DateTime(today.Year, result.Date.Date.Month, DateTime.DaysInMonth(today.Year, result.Date.Date.Month), 23, 59, 59);

                var appointments = await AppointmentApiClient.GetAppointmentsByDate(startTime, endTime);

                if (appointments != null && appointments.Any())
                {
                    model.Appointments = appointments;
                }
            }

            return View("Index", model);
        }

    }
}
