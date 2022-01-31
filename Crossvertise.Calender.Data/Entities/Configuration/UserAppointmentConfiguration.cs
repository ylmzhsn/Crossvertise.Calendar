namespace Crossvertise.Calender.Data.Entities.Configuration
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// User Appointment Entity Configuration Class
    /// </summary>
    class UserAppointmentConfiguration : IEntityTypeConfiguration<UserAppointment>
    {
        public void Configure(EntityTypeBuilder<UserAppointment> builder)
        {
            builder.ToTable("UserAppointment");

            builder.Property(t => t.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasKey(t => new { t.UserId, t.AppointmentId });

            builder.HasOne(t => t.Appointment)
                   .WithMany(t => t.UserAppointment)
                   .HasForeignKey(t => t.AppointmentId)
                   .HasConstraintName("FK_UserAppointment_Appointments_AppointmentId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.User)
                   .WithMany(p => p.UserAppointment)
                   .HasForeignKey(t => t.UserId)
                   .HasConstraintName("FK_UserAppointment_Users_UserId")
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData
            (
                //Appointment 1
                new UserAppointment
                {
                    AppointmentId = 1,
                    UserId = 1
                },
                new UserAppointment
                {
                    AppointmentId = 1,
                    UserId = 2
                },
                 new UserAppointment
                 {
                     AppointmentId = 1,
                     UserId = 3
                 },
                 new UserAppointment
                 {
                     AppointmentId = 1,
                     UserId = 4
                 },

                 //Appointment 2
                 new UserAppointment
                 {
                     AppointmentId = 2,
                     UserId = 1
                 },
                 new UserAppointment
                 {
                     AppointmentId = 2,
                     UserId = 2
                 },

                 //Appointment 3
                 new UserAppointment
                 {
                     AppointmentId = 3,
                     UserId = 1
                 },
                 new UserAppointment
                 {
                     AppointmentId = 3,
                     UserId = 2
                 },
                 new UserAppointment
                 {
                     AppointmentId = 3,
                     UserId = 3
                 },
                 new UserAppointment
                 {
                     AppointmentId = 3,
                     UserId = 4
                 }
            );
        }
    }
}
