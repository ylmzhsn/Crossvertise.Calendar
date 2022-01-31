namespace Crossvertise.Calender.Data.Entities.Configuration
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    /// <summary>
    /// Appointment Entity Configuration Class
    /// </summary>
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");

            builder.Property(t => t.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasData
            (
                new Appointment
                {
                    Id = 1,
                    OrganizerId = 1,
                    Description = "Project Meeting",
                    Date = new DateTime(2022, 1, 30, 17, 0, 0)
                },
                new Appointment
                {
                    Id = 2,
                    OrganizerId = 1,
                    Description = "Lunch with John",
                    Date = new DateTime(2022, 1, 31, 12, 0, 0)
                },
                new Appointment
                {
                    Id = 3,
                    OrganizerId = 2,
                    Description = "Team Meeting",
                    Date = new DateTime(2022, 2, 1, 17, 0, 0)
                }
            );
        }
    }
}
