namespace Crossvertise.Calender.Data.Entities
{
    using Crossvertise.Calender.Data.Abstract;

    /// <summary>
    /// User Appointment 
    /// </summary>
    public class UserAppointment : BaseEntity<long>
    {
        public long UserId { get; set; }

        public User User { get; set; }

        public long AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

    }
}
