namespace Crossvertise.Calendar.Service.ApiClients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    using Newtonsoft.Json;

    using Crossvertise.Calendar.Service.Models;

    /// <summary>
    /// Appointment Api Client
    /// </summary>
    public static class AppointmentApiClient
    {
        public static async Task<AppointmentModel> GetAppointmentDetail(long id)
        {
            var appointment = new AppointmentModel();

            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:44345/api/calendar/appointment/detail?id={id}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AppointmentModel>(data); ;
        }

        public static async Task<List<AppointmentModel>> GetAllAppointments()
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://localhost:44345/api/calendar/appointment/all");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<AppointmentModel>>(data);
        }

        public static async Task<List<AppointmentModel>> GetAppointmentsByDate(DateTime startTime, DateTime endTime)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:44345/api/calendar/appointment/byDate?startTime={startTime}&endTime={endTime}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<AppointmentModel>>(data);
        }
    }
}
