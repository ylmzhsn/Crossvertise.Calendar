namespace Crossvertise.Calendar.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Microsoft.AspNetCore.Mvc;

    using Crossvertise.Calendar.Service.Business.Abstract;
    using Crossvertise.Calendar.Service.Models;

    [Route("api/[controller]/appointment")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public CalendarController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet, Route("detail")]
        [ProducesResponseType(typeof(AppointmentModel), (int)HttpStatusCode.OK)]
        public ActionResult<AppointmentModel> GetAppointment(long id)
        {
            var appointment = _appointmentService.GetAppointmentDetail(id);

            return Ok(appointment);
        }

        [HttpGet, Route("all")]
        [ProducesResponseType(typeof(List<AppointmentModel>), (int)HttpStatusCode.OK)]
        public ActionResult<List<AppointmentModel>> GetAllAppointment()
        {
            var appointments = _appointmentService.GetAllAppointments();

            return Ok(appointments);
        }

        [HttpGet, Route("byDate")]
        [ProducesResponseType(typeof(List<AppointmentModel>), (int)HttpStatusCode.OK)]
        public ActionResult<List<AppointmentModel>> GetAppointmentsByDate(DateTime startTime, DateTime endTime)
        {
            var appointments = _appointmentService.GetAppointmentsByDate(startTime, endTime);

            return Ok(appointments);
        }
    }
}
